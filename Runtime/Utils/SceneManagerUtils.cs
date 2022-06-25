using System.Linq;
using LiteNinja.Utils.Extensions;
using UnityEngine.SceneManagement;

namespace LiteNinja.Utils
{
    public static class SceneManagerUtils
    {
        /// <summary>
        /// Finds game objects in active scene with T component.
        /// </summary>
        public static T[] FindObjectsOfTypeInActiveScene<T>() => SceneManager.GetActiveScene().FindObjectsOfType<T>();

        /// <summary>
        /// Finds game objects in open scenes with T component.
        /// </summary>
        public static T[] FindObjectsOfTypeInOpenScenes<T>() => Enumerable.Range(0, SceneManager.sceneCount)
            .Select(SceneManager.GetSceneAt).SelectMany(scene => scene.FindObjectsOfType<T>())
            .ToArray();
    }
}