using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.Utils.Extensions
{
    public static class GameObjectExtensions
    {
        public static GameObject[] GetChildren(this GameObject self)
        {
            return (from Transform ch in self.transform select ch.gameObject).ToArray();
        }

        public static GameObject FindWithDisabled(this GameObject self, string name)
        {
            var temp = Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[];
            var obj = new GameObject();
            if (temp == null) return obj;
            foreach (var o in temp)
            {
                if (o.name == name)
                {
                    obj = o;
                }
            }

            return obj;
        }

        public static void SetActiveSafe(this GameObject self, bool value)
        {
            if (self.activeSelf != value)
            {
                self.SetActive(value);
            }
        }
        
        public static void SetActiveWithParent(this GameObject self, bool value)
        {
            self.SetActive(value);
            self.transform.parent.gameObject.SetActive(value);
        }


        public static bool HasComponent<T>(this GameObject self) where T : Component
        {
            return self.GetComponent<T>() != null;
        }

        public static T GetComponent<T>(this GameObject self, Action<T> callback) where T : Component
        {
            var component = self.GetComponent<T>();

            if (component != null)
            {
                callback.Invoke(component);
            }

            return component;
        }

        public static T GetComponentRequired<T>(this GameObject self, Action<T> callback) where T : Component
        {
            var component = self.GetComponentRequired<T>();

            if (component != null)
            {
                callback.Invoke(component);
            }

            return component;
        }

        public static T GetComponent<T>(this GameObject self, Action<T> success, Action failure)
            where T : Component
        {
            var component = self.GetComponent<T>();

            if (component != null)
            {
                success.Invoke(component);
                return component;
            }

            failure.Invoke();
            return null;
        }

        public static T GetOrAddComponent<T>(this GameObject self) where T : Component
        {
            var component = self.GetComponent<T>();

            if (component == null)
            {
                component = self.AddComponent<T>();
            }

            return component;
        }

        public static T GetComponentRequired<T>(this GameObject self) where T : Component
        {
            var component = self.GetComponent<T>();

            if (component == null)
            {
                throw new Exception("Could not find " + typeof(T) + " on " + self.name);
            }

            return component;
        }

        public static T GetComponentInParentAndChildren<T>(this GameObject self)
        {
            if (self.GetComponentInParent<T>() != null)
            {
                return self.GetComponentInParent<T>();
            }

            return self.GetComponentInChildren<T>() ?? self.GetComponent<T>();
        }

        public static List<T> GetComponentsInParentAndChildren<T>(this GameObject self) where T : Component
        {
            var _list = new List<T>(self.GetComponents<T>());

            _list.AddRange(new List<T>(self.GetComponentsInChildren<T>()));
            _list.AddRange(new List<T>(self.GetComponentsInParent<T>()));

            return _list;
        }

        public static T[] GetComponentsInDirectChildren<T>(this GameObject self) where T : Component
        {
            return self.transform.GetComponentsInDirectChildren<T>();
        }

        public static void Trigger(this GameObject self, UnityEvent evt)
        {
            evt?.Invoke();
        }

        public static void Trigger<T>(this GameObject self, UnityEvent<T> evt, T data)
        {
            evt?.Invoke(data);
        }

        public static RectTransform RectTransform(this GameObject self)
        {
            return self.transform as RectTransform;
        }
    }
}