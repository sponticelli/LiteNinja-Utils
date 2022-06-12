using System.Collections.Generic;
using UnityEngine;

namespace com.liteninja.utils
{
    public static class GameObjectExtensions
    {
        public static void SetActiveSafe(this GameObject self, bool value)
        {
            if (self.activeSelf != value)
            {
                self.SetActive(value);
            }
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
    }
}