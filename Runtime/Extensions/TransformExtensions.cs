using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace com.liteninja.utils
{
    public static class TransformExtensions
    {
        public static Transform Clone(this Transform self, string rename = null)
        {
            var name = self.name;
            if (!string.IsNullOrEmpty(rename)) name = rename;
            var clone = new GameObject(name);
            clone.transform.AlignTo(self);
            clone.transform.localScale = self.lossyScale;
            return clone.transform;
        }
        public static float SqrDistance(this Transform self, Transform other)
        {
            return self.position.SqrDistance(other.position);
        }

        public static float SqrDistance(this Transform self, Vector3 other)
        {
            return self.position.SqrDistance(other);
        }

        public static float SqrDistance2D(this Transform self, Transform other)
        {
            return self.position.SetY(0).SqrDistance(other.position.SetY(0));
        }

        public static float SqrDistance2D(this Transform self, Vector3 other)
        {
            return self.position.SetY(0).SqrDistance(other.SetY(0));
        }

        public static Transform[] GetDirectChildren(this Transform self)
        {
            var children = new Transform[self.childCount];

            for (var i = 0; i < self.childCount; i++)
                children[i] = self.GetChild(i);

            return children;
        }

        public static T[] GetComponentsInDirectChildren<T>(this Transform self) where T : Component
        {
            var components = new List<T>();

            for (var i = 0; i < self.childCount; i++)
            {
                var component = self.GetChild(i).GetComponent<T>();
                if (component != null) components.Add(component);
            }

            return components.ToArray();
        }


        public static void SetPositionX(this Transform self, float x)
        {
            var position = self.position;
            position = new Vector3(x, position.y, position.z);
            self.position = position;
        }

        public static void SetPositionY(this Transform self, float y)
        {
            var position = self.position;
            position = new Vector3(position.x, y, position.z);
            self.position = position;
        }

        public static void SetPositionZ(this Transform self, float z)
        {
            var position = self.position;
            position = new Vector3(position.x, position.y, z);
            self.position = position;
        }

        public static void AddPositionX(this Transform self, float x)
        {
            self.SetPositionX(x + self.position.x);
        }

        public static void AddPositionY(this Transform self, float y)
        {
            self.SetPositionY(y + self.position.y);
        }

        public static void AddPositionZ(this Transform self, float z)
        {
            self.SetPositionZ(z + self.position.z);
        }

        public static void SetLocalPositionX(this Transform self, float x)
        {
            var localPosition = self.localPosition;
            localPosition = new Vector3(x, localPosition.y, localPosition.z);
            self.localPosition = localPosition;
        }

        public static void SetLocalPositionY(this Transform self, float y)
        {
            var localPosition = self.localPosition;
            localPosition = new Vector3(localPosition.x, y, localPosition.z);
            self.localPosition = localPosition;
        }

        public static void SetLocalPositionZ(this Transform self, float z)
        {
            var localPosition = self.localPosition;
            localPosition = new Vector3(localPosition.x, localPosition.y, z);
            self.localPosition = localPosition;
        }

        public static void AddLocalPositionX(this Transform self, float x)
        {
            self.SetLocalPositionX(x + self.localPosition.x);
        }

        public static void AddLocalPositionY(this Transform self, float y)
        {
            self.SetLocalPositionY(y + self.localPosition.y);
        }

        public static void AddLocalPositionZ(this Transform self, float z)
        {
            self.SetLocalPositionZ(z + self.localPosition.z);
        }

        public static void SetEulerAngleX(this Transform self, float x)
        {
            var eulerAngles = self.eulerAngles;
            eulerAngles = new Vector3(x, eulerAngles.y, eulerAngles.z);
            self.eulerAngles = eulerAngles;
        }

        public static void SetEulerAngleY(this Transform self, float y)
        {
            var eulerAngles = self.eulerAngles;
            eulerAngles = new Vector3(eulerAngles.x, y, eulerAngles.z);
            self.eulerAngles = eulerAngles;
        }

        public static void SetEulerAngleZ(this Transform self, float z)
        {
            var eulerAngles = self.eulerAngles;
            eulerAngles = new Vector3(eulerAngles.x, eulerAngles.y, z);
            self.eulerAngles = eulerAngles;
        }

        public static void AddEulerAngleX(this Transform self, float x)
        {
            self.SetEulerAngleX(self.eulerAngles.x + x);
        }

        public static void AddEulerAngleY(this Transform self, float y)
        {
            self.SetEulerAngleY(self.eulerAngles.y + y);
        }

        public static void AddEulerAngleZ(this Transform self, float z)
        {
            self.SetEulerAngleZ(self.eulerAngles.z + z);
        }

        public static void SetLocalEulerAngleX(this Transform self, float x)
        {
            var localEulerAngles = self.localEulerAngles;
            localEulerAngles = new Vector3(x, localEulerAngles.y, localEulerAngles.z);
            self.localEulerAngles = localEulerAngles;
        }

        public static void SetLocalEulerAngleY(this Transform self, float y)
        {
            var localEulerAngles = self.localEulerAngles;
            localEulerAngles = new Vector3(localEulerAngles.x, y, localEulerAngles.z);
            self.localEulerAngles = localEulerAngles;
        }

        public static void SetLocalEulerAngleZ(this Transform self, float z)
        {
            var localEulerAngles = self.localEulerAngles;
            localEulerAngles = new Vector3(localEulerAngles.x, localEulerAngles.y, z);
            self.localEulerAngles = localEulerAngles;
        }

        public static void AddLocalEulerAngleX(this Transform self, float x)
        {
            self.SetLocalEulerAngleX(self.localEulerAngles.x + x);
        }

        public static void AddLocalEulerAngleY(this Transform self, float y)
        {
            self.SetLocalEulerAngleY(self.localEulerAngles.y + y);
        }

        public static void AddLocalEulerAngleZ(this Transform self, float z)
        {
            self.SetLocalEulerAngleZ(self.localEulerAngles.z + z);
        }

        public static void SetLocalScaleX(this Transform self, float x)
        {
            var localScale = self.localScale;
            localScale = new Vector3(x, localScale.y, localScale.z);
            self.localScale = localScale;
        }

        public static void SetLocalScaleY(this Transform self, float y)
        {
            var localScale = self.localScale;
            localScale = new Vector3(localScale.x, y, localScale.z);
            self.localScale = localScale;
        }

        public static void SetLocalScaleZ(this Transform self, float z)
        {
            var localScale = self.localScale;
            localScale = new Vector3(localScale.x, localScale.y, z);
            self.localScale = localScale;
        }

        public static void AddLocalScaleX(this Transform self, float x)
        {
            self.SetLocalScaleX(self.localScale.x + x);
        }

        public static void AddLocalScaleY(this Transform self, float y)
        {
            self.SetLocalScaleY(self.localScale.y + y);
        }

        public static void AddLocalScaleZ(this Transform self, float z)
        {
            self.SetLocalScaleZ(self.localScale.z + z);
        }

        public static void Reset(this Transform self)
        {
            self.localPosition = Vector3.zero;
            self.localScale = Vector3.one;
            self.localRotation = Quaternion.identity;
        }
        
        public static void LookAt(this Transform self, GameObject target)
        {
            self.LookAt(target.transform);
        }
        
        public static Quaternion GetLookAtRotation(this Transform self, Vector3 target)
        {
            return Quaternion.LookRotation(target - self.position);
        }
        public static Quaternion GetLookAtRotation(this Transform self, Transform target)
        {
            return GetLookAtRotation(self, target.position);
        }
        public static Quaternion GetLookAtRotation(this Transform self, GameObject target)
        {
            return GetLookAtRotation(self, target.transform.position);
        }
        public static void LookAwayFrom(this Transform self, Vector3 target)
        {
            self.rotation = GetLookAwayFromRotation(self, target);
        }
        public static void LookAwayFrom(this Transform self, Transform target)
        {
            self.rotation = GetLookAwayFromRotation(self, target);
        }
        public static void LookAwayFrom(this Transform self, GameObject target)
        {
            self.rotation = GetLookAwayFromRotation(self, target);
        }
        public static Quaternion GetLookAwayFromRotation(this Transform self, Vector3 target)
        {
            return Quaternion.LookRotation(self.position - target);
        }
        public static Quaternion GetLookAwayFromRotation(this Transform self, Transform target)
        {
            return GetLookAwayFromRotation(self, target.position);
        }
        public static Quaternion GetLookAwayFromRotation(this Transform self, GameObject target)
        {
            return GetLookAwayFromRotation(self, target.transform.position);
        }
        
        public static void AlignTo(this Transform me, Transform other)
        {
            me.position = other.position;
            me.rotation = me.rotation;
        }

        /// <summary>
        /// Sets sibling index to previous.
        /// </summary>
        public static void SetToPreviousSibling(this Transform self) =>
            self.SetSiblingIndex(self.GetSiblingIndex() - 1);

        /// <summary>
        /// Sets sibling index to next.
        /// </summary>
        public static void SetToNextSibling(this Transform self) =>
            self.SetSiblingIndex(self.GetSiblingIndex() + 1);

        /// <summary>
        /// Gets list of all children.
        /// </summary>
        public static List<Transform> GetChildren(this Transform self) => Enumerable.Range(0, self.childCount)
            .Select(self.GetChild).ToList();
        
        public static Transform FindDeepChild(this Transform self, string name, bool includeInactive = true)
        {
            var result = self.Find(name);
            if (result != null)
                return result;

            foreach (Transform child in self)
            {
                result = child.FindDeepChild(name);
                if (result != null)
                    return result;
            }

            return null;
        }

        /// <summary>
        /// Adds children to transform.
        /// </summary>
        public static void AddChildren(this Transform self, params Transform[] children) =>
            AddChildren(self, (IEnumerable<Transform>)children);

        /// <summary>
        /// Adds children to transform.
        /// </summary>
        public static void AddChildren(this Transform self, IEnumerable<Transform> children)
        {
            foreach (var child in children)
                child.parent = self;
        }

        /// <summary>
        /// Destroy all children.
        /// </summary>
        public static void DestroyChildren(this Transform self) =>
            GetChildren(self).ForEach(child => Object.Destroy(child.gameObject));

        /// <summary>
        /// Destroy all children by condition.
        /// </summary>
        public static void DestroyChildrenChildrenWhere(this Transform self, Predicate<Transform> predicate)
        {
            var filtered = GetChildren(self).Where(c => predicate(c));

            foreach (var child in filtered)
                Object.Destroy(child.gameObject);
        }

        /// <summary>
        /// Destroy child by index.
        /// </summary>
        public static void DestroyChild(this Transform self, int index) =>
            Object.Destroy(self.GetChild(index).gameObject);

        /// <summary>
        /// Destroy first child.
        /// </summary>
        public static void DestroyFirstChild(this Transform self) => DestroyChild(self, 0);

        /// <summary>
        /// Destroy last child.
        /// </summary>
        public static void DestroyLastChild(this Transform self) => DestroyChild(self, self.childCount - 1);
        
        public static void TraverseHierarchy(this Transform self, Action<Transform> operate, int depthLimit = -1)
        {
            operate(self);

            if (depthLimit == 0) return;
            var count = self.childCount;
            for (var i = 0; i < count; i++)
            {
                TraverseHierarchy(self.GetChild(i), operate, depthLimit - 1);
            }
        }

        public static void InverseTraverseHierarchy(this Transform self, Action<Transform> operate, int depthLimit = -1)
        {
            if (depthLimit != 0)
            {
                var count = self.childCount;
                for (var i = 0; i < count; i++)
                {
                    InverseTraverseHierarchy(self.GetChild(i), operate, depthLimit - 1);
                }
            }

            operate(self);
        }

        public static Transform SearchHierarchy(this Transform self, Predicate<Transform> match, int depthLimit = -1)
        {
            if (match(self)) return self;
            if (depthLimit == 0) return null;

            var count = self.childCount;
            Transform result = null;

            for (var i = 0; i < count; i++)
            {
                result = SearchHierarchy(self.GetChild(i), match, depthLimit - 1);
                if (result) break;
            }

            return result;
        }
    }
}