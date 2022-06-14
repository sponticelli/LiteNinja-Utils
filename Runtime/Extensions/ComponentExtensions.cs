using UnityEngine;

namespace com.liteninja.utils
{
    public static class ComponentExtensions
    {
        public static T GetOrAddComponent<T>(this Component self) where T : Component
        {
            return self.gameObject.GetOrAddComponent<T>();
        }
        
        public static RectTransform rectTransform(this Component self)
        {
            return self.transform as RectTransform;
        }
    }
}