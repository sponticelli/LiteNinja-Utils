using UnityEngine;

namespace LiteNinja.Utils.Extensions
{
    public static class RenderTextureExtensions {
        public static Texture2D ToTexture2D(this RenderTexture rTex)
        {
            var tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGB24, false);
            RenderTexture.active = rTex;
            tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
            tex.Apply();
            return tex;
        }
    }
}