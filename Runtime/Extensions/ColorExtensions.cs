using UnityEngine;

namespace com.liteninja.utils
{
    public static class ColorExtensions
    {
        public static uint ToHex(this Color color)
        {
            var r = (uint)(color.r * 255) << 24;
            var g = (uint)(color.g * 255) << 16;
            var b = (uint)(color.b * 255) << 8;
            var a = (uint)(color.a * 255);
            return r + g + b + a;
        }
    }
}