using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace LiteNinja.Utils.Extensions
{
    public static class SceneManagerExtensions
    {
        public static Scene[] GetAllLoadedScenes(this SceneManager sc)
        {
            var scenes = new List<Scene>();
            for (var i = 0; i < SceneManager.sceneCount; i++)
            {
                scenes.Add(SceneManager.GetSceneAt(i));
            }
            return scenes.ToArray();
        }
    }
}