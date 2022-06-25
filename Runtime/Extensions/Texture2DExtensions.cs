using System.IO;
using UnityEngine;

namespace LiteNinja.Utils.Extensions
{
    public static class Texture2DExtensions
    {

        public static void SaveToPNG(this Texture2D self, string path)
        {
            var bytes = self.EncodeToPNG();
            File.WriteAllBytes(path, bytes);
        }
    }
}