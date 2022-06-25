using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.IO;
using UnityEditor.Callbacks;

namespace LiteNinja.Utils.Editor
{
    public class ConstantsGenerator : UnityEditor.Editor
    {
        private const string ConstantsFileName = "ConstantsReference";
        private const string TagsFileName = "Tags";
        private const string SortingLayersFileName = "SortingLayers";
        private const string LayersFileName = "Layers";

        [MenuItem("LiteNinja/Consts/Generate Constants")]
        public static void GenerateConstants()
        {
            var fileContents =
                "using System;\nusing System.Collections;\nusing UnityEngine;\nusing UnityEngine.SceneManagement;\n\n";
            fileContents += "namespace ConstantsRef\n{\n";

            fileContents += GenerateTags();
            fileContents += GenerateLayers();
            fileContents += GenerateSortingLayers();

            fileContents += "}";

            File.WriteAllText(Application.dataPath + "/" + ConstantsFileName + ".cs", fileContents);
        }

        [PostProcessScene, DidReloadScripts]
        private static void OnPostProcessSceneOrScripts()
        {
            EditorApplication.hierarchyChanged -= GenerateConstants;
            EditorApplication.hierarchyChanged += GenerateConstants;

            GenerateConstants();
        }

        private static string GenerateTags()
        {
            var tags = InternalEditorUtility.tags;
            var tagsCount = tags.Length;

            var fileContents = "";

            fileContents += "\tpublic static class " + TagsFileName + "\n\t{\n";
            for (var i = 0; i < tagsCount; i++)
            {
                fileContents += "\t\tpublic static readonly string " + tags[i] + " = \"" + tags[i] + "\";\n";
            }

            fileContents += "\t}\n\n";

            return fileContents;
        }

        private static string GenerateSortingLayers()
        {
            var sortingLayers = SortingLayer.layers;

            var tagsCount = sortingLayers.Length;

            var fileContents = "";

            fileContents += "\tpublic static class " + SortingLayersFileName + "\n\t{\n";

            for (var i = 0; i < tagsCount; i++)
            {
                fileContents += "\t\tpublic static readonly SortingLayer " + sortingLayers[i].name +
                                " = SortingLayer.layers[" + i + "];\n";
            }

            fileContents += "\n";
            fileContents += "\t\tpublic static class ByValue\n\t\t{\n";

            for (var i = 0; i < tagsCount; i++)
            {
                fileContents += "\t\t\tpublic static readonly int " + sortingLayers[i].name + " = " +
                                sortingLayers[i].value + ";\n";
            }

            fileContents += "\t\t}\n\n";

            fileContents += "\t\tpublic static class ByName\n\t\t{\n";

            for (var i = 0; i < tagsCount; i++)
            {
                fileContents += "\t\t\tpublic static readonly string " + sortingLayers[i].name + " = \"" +
                                sortingLayers[i].name + "\";\n";
            }

            fileContents += "\t\t}\n";

            fileContents += "\t}\n\n";

            return fileContents;
        }


        private static string GenerateLayers()
        {
            var layers = InternalEditorUtility.layers;
            var layersCount = layers.Length;

            var fileContents = "";

            fileContents += "\tpublic static class " + LayersFileName + "\n\t{\n";

            for (var i = 0; i < layersCount; i++)
            {
                var layerIndex = LayerMask.NameToLayer(layers[i]);
                fileContents += "\t\tpublic static readonly int " + layers[i].Replace(" ", "") + " = " + layerIndex + ";\n";
            }

            fileContents += "\n";

            fileContents += "\t\tpublic static class ByName\n\t\t{\n";
            for (var i = 0; i < layersCount; i++)
            {
                fileContents += "\t\t\tpublic static readonly string " + layers[i].Replace(" ", "") + " = \"" + layers[i] +
                                "\";\n";
            }

            fileContents += "\t\t}\n\n";

            fileContents +=
                "\t\tpublic static bool IsValueOnMask(int layer, LayerMask mask)\n" +
                "\t\t{\n" +
                "\t\t\treturn (mask == (mask | (1 << layer)));\n" +
                "\t\t}\n";

            fileContents += "\t}\n\n";

            return fileContents;
        }
    }
}