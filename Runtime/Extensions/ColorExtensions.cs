using UnityEngine;

namespace LiteNinja.Utils.Extensions
{
    public static class ColorExtensions
    {
        public static uint ToHex(this Color self)
        {
            var r = (uint)(self.r * 255) << 24;
            var g = (uint)(self.g * 255) << 16;
            var b = (uint)(self.b * 255) << 8;
            var a = (uint)(self.a * 255);
            return r + g + b + a;
        }
        
        public static Color Clone(this Color self)
        {
            return new Color(self.r, self.g, self.b, self.a);
        }
    }
}