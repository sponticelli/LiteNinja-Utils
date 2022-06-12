using System.Linq;
using UnityEngine.SceneManagement;

namespace com.liteninja.utils
{
    public static class SceneExtensions
    {
        /// <summary>
        /// Finds game objects in scene with T component.
        /// </summary>
        public static T[] FindObjectsOfType<T>(this Scene self) => self.GetRootGameObjects()
            .SelectMany(go => go.GetComponentsInChildren<T>(true)).ToArray();
    }
}