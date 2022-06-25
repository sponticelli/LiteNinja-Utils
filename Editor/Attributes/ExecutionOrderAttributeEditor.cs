using System;
using System.Collections.Generic;
using System.Linq;
using LiteNinja.Utils.Attributes;
using UnityEditor;
using UnityEngine;

namespace LiteNinja.Utils.Editor
{
    public static class ExecutionOrderAttributeEditor
    {
        private static class Graph
        {
            public struct Edge
            {
                public MonoScript node;
                public int weight;
            }

            public static Dictionary<MonoScript, List<Edge>> Create(
                IEnumerable<ScriptExecutionOrderDefinition> definitions,
                List<ScriptExecutionOrderDependency> dependencies)
            {
                var graph = new Dictionary<MonoScript, List<Edge>>();

                foreach (var dependency in dependencies)
                {
                    var source = dependency.firstScript;
                    var dest = dependency.secondScript;
                    if (!graph.TryGetValue(source, out var edges))
                    {
                        edges = new List<Edge>();
                        graph.Add(source, edges);
                    }

                    edges.Add(new Edge { node = dest, weight = dependency.orderDelta });
                    if (!graph.ContainsKey(dest))
                    {
                        graph.Add(dest, new List<Edge>());
                    }
                }

                foreach (var node in definitions
                    .Select(definition => definition.script)
                    .Where(node => !graph.ContainsKey(node)))
                {
                    graph.Add(node, new List<Edge>());
                }

                return graph;
            }

            private static bool IsCyclicRecursion(IReadOnlyDictionary<MonoScript, List<Edge>> graph, MonoScript node,
                IDictionary<MonoScript, bool> visited, IDictionary<MonoScript, bool> inPath)
            {
                if (visited[node]) return inPath[node];
                visited[node] = true;
                inPath[node] = true;

                foreach (var edge in graph[node])
                {
                    var nextNode = edge.node;
                    if (!IsCyclicRecursion(graph, nextNode, visited, inPath)) continue;
                    inPath[node] = false;
                    return true;
                }

                inPath[node] = false;
                return false;
            }

            public static bool IsCyclic(Dictionary<MonoScript, List<Edge>> graph)
            {
                var visited = new Dictionary<MonoScript, bool>();
                var inPath = new Dictionary<MonoScript, bool>();
                foreach (var node in graph.Keys)
                {
                    visited.Add(node, false);
                    inPath.Add(node, false);
                }

                return graph.Keys.Any(node => IsCyclicRecursion(graph, node, visited, inPath));
            }

            public static List<MonoScript> GetRoots(Dictionary<MonoScript, List<Edge>> graph)
            {
                var degrees = graph.Keys.ToDictionary(node => node, node => 0);

                foreach (var nextNode in from kvp in graph
                    let node = kvp.Key
                    select kvp.Value
                    into edges
                    from edge in edges
                    select edge.node)
                {
                    degrees[nextNode]++;
                }

                return (from kvp in degrees let node = kvp.Key let degree = kvp.Value where degree == 0 select node)
                    .ToList();
            }

            public static void PropagateValues(IReadOnlyDictionary<MonoScript, List<Edge>> graph,
                Dictionary<MonoScript, int> values)
            {
                var queue = new Queue<MonoScript>();

                foreach (var node in values.Keys)
                    queue.Enqueue(node);

                while (queue.Count > 0)
                {
                    var node = queue.Dequeue();
                    var currentValue = values[node];

                    foreach (var edge in graph[node])
                    {
                        var nextNode = edge.node;
                        var newValue = currentValue + edge.weight;
                        var hasPrevValue = values.TryGetValue(nextNode, out var prevValue);
                        var newValueBeyond = edge.weight > 0 ? newValue > prevValue : newValue < prevValue;
                        if (hasPrevValue && !newValueBeyond) continue;
                        values[nextNode] = newValue;
                        queue.Enqueue(nextNode);
                    }
                }
            }
        }

        private struct ScriptExecutionOrderDefinition
        {
            public MonoScript script { get; set; }
            public int order { get; set; }
        }

        private struct ScriptExecutionOrderDependency
        {
            public MonoScript firstScript { get; set; }
            public MonoScript secondScript { get; set; }
            public int orderDelta { get; set; }
        }

        private static Dictionary<Type, MonoScript> GetTypeDictionary()
        {
            var types = new Dictionary<Type, MonoScript>();

            var scripts = MonoImporter.GetAllRuntimeMonoScripts();
            foreach (var script in scripts)
            {
                var type = script.GetClass();
                if (!IsTypeValid(type)) continue;
                if (!types.ContainsKey(type))
                    types.Add(type, script);
            }

            return types;
        }

        private static bool IsTypeValid(Type type)
        {
            if (type != null)
                return type.IsSubclassOf(typeof(MonoBehaviour)) || type.IsSubclassOf(typeof(ScriptableObject));
            return false;
        }

        private static List<ScriptExecutionOrderDependency> GetExecutionOrderDependencies(
            Dictionary<Type, MonoScript> types)
        {
            var list = new List<ScriptExecutionOrderDependency>();

            foreach (var (type, script) in types)
            {
                var hasExecutionOrderAttribute = Attribute.IsDefined(type, typeof(ExecutionOrderAttribute));
                var hasExecuteAfterAttribute = Attribute.IsDefined(type, typeof(ExecuteAfterAttribute));
                var hasExecuteBeforeAttribute = Attribute.IsDefined(type, typeof(ExecuteBeforeAttribute));

                if (hasExecuteAfterAttribute)
                {
                    if (hasExecutionOrderAttribute)
                    {
                        Debug.LogError(
                            $"Script {script.name} has both [ExecutionOrder] and [ExecuteAfter] attributes. Ignoring the [ExecuteAfter] attribute.",
                            script);
                        continue;
                    }

                    var attributes =
                        (ExecuteAfterAttribute[])Attribute.GetCustomAttributes(type, typeof(ExecuteAfterAttribute));
                    foreach (var attribute in attributes)
                    {
                        if (attribute.orderIncrease < 0)
                        {
                            Debug.LogError(
                                $"Script {script.name} has an [ExecuteAfter] attribute with a negative orderIncrease. Use the [ExecuteBefore] attribute instead. Ignoring this [ExecuteAfter] attribute.",
                                script);
                            continue;
                        }

                        if (!attribute.targetType.IsSubclassOf(typeof(MonoBehaviour)) &&
                            !attribute.targetType.IsSubclassOf(typeof(ScriptableObject)))
                        {
                            Debug.LogError(
                                $"Script {script.name} has an [ExecuteAfter] attribute with targetScript={attribute.targetType.Name} which is not a MonoBehaviour nor a ScriptableObject. Ignoring this [ExecuteAfter] attribute.",
                                script);
                            continue;
                        }

                        var targetScript = types[attribute.targetType];
                        var dependency = new ScriptExecutionOrderDependency
                            { firstScript = targetScript, secondScript = script, orderDelta = attribute.orderIncrease };
                        list.Add(dependency);
                    }
                }

                if (!hasExecuteBeforeAttribute) continue;

                if (hasExecutionOrderAttribute)
                {
                    Debug.LogError(
                        $"Script {script.name} has both [ExecutionOrder] and [ExecuteBefore] attributes. Ignoring the [ExecuteBefore] attribute.",
                        script);
                    continue;
                }

                if (hasExecuteAfterAttribute)
                {
                    Debug.LogError(
                        $"Script {script.name} has both [ExecuteAfter] and [ExecuteBefore] attributes. Ignoring the [ExecuteBefore] attribute.",
                        script);
                    continue;
                }

                var customAttributes =
                    (ExecuteBeforeAttribute[])Attribute.GetCustomAttributes(type, typeof(ExecuteBeforeAttribute));
                foreach (var attribute in customAttributes)
                {
                    if (attribute.orderDecrease < 0)
                    {
                        Debug.LogError(
                            $"Script {script.name} has an [ExecuteBefore] attribute with a negative orderDecrease. Use the [ExecuteAfter] attribute instead. Ignoring this [ExecuteBefore] attribute.",
                            script);
                        continue;
                    }

                    if (!attribute.targetType.IsSubclassOf(typeof(MonoBehaviour)) &&
                        !attribute.targetType.IsSubclassOf(typeof(ScriptableObject)))
                    {
                        Debug.LogError(
                            $"Script {script.name} has an [ExecuteBefore] attribute with targetScript={attribute.targetType.Name} which is not a MonoBehaviour nor a ScriptableObject. Ignoring this [ExecuteBefore] attribute.",
                            script);
                        continue;
                    }

                    var targetScript = types[attribute.targetType];
                    var dependency = new ScriptExecutionOrderDependency
                    {
                        firstScript = targetScript, secondScript = script, orderDelta = -attribute.orderDecrease
                    };
                    list.Add(dependency);
                }
            }

            return list;
        }

        private static List<ScriptExecutionOrderDefinition> GetExecutionOrderDefinitions(
            Dictionary<Type, MonoScript> types)
        {
            return (from kvp in types
                let type = kvp.Key
                let script = kvp.Value
                where Attribute.IsDefined(type, typeof(ExecutionOrderAttribute))
                let attribute =
                    (ExecutionOrderAttribute)Attribute.GetCustomAttribute(type, typeof(ExecutionOrderAttribute))
                select new ScriptExecutionOrderDefinition { script = script, order = attribute.order }).ToList();
        }

        private static Dictionary<MonoScript, int> GetInitalExecutionOrder(
            List<ScriptExecutionOrderDefinition> definitions,
            List<MonoScript> graphRoots)
        {
            var orders = new Dictionary<MonoScript, int>();
            foreach (var definition in definitions)
            {
                var script = definition.script;
                var order = definition.order;
                orders.Add(script, order);
            }

            foreach (var script in graphRoots)
            {
                if (!orders.ContainsKey(script))
                {
                    var order = MonoImporter.GetExecutionOrder(script);
                    orders.Add(script, order);
                }
            }

            return orders;
        }

        private static void UpdateExecutionOrder(Dictionary<MonoScript, int> orders)
        {
            var startedEdit = false;

            foreach (var kvp in orders)
            {
                var script = kvp.Key;
                var order = kvp.Value;

                if (MonoImporter.GetExecutionOrder(script) != order)
                {
                    if (!startedEdit)
                    {
                        AssetDatabase.StartAssetEditing();
                        startedEdit = true;
                    }

                    MonoImporter.SetExecutionOrder(script, order);
                }
            }

            if (startedEdit)
            {
                AssetDatabase.StopAssetEditing();
            }
        }

        [UnityEditor.Callbacks.DidReloadScripts]
        private static void OnDidReloadScripts()
        {
            var types = GetTypeDictionary();
            var definitions = GetExecutionOrderDefinitions(types);
            var dependencies = GetExecutionOrderDependencies(types);
            var graph = Graph.Create(definitions, dependencies);

            if (Graph.IsCyclic(graph))
            {
                Debug.LogError("Circular script execution order definitions");
                return;
            }

            var roots = Graph.GetRoots(graph);
            var orders = GetInitalExecutionOrder(definitions, roots);
            Graph.PropagateValues(graph, orders);

            UpdateExecutionOrder(orders);
        }
    }
}