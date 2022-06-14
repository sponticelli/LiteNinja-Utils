using UnityEngine;

namespace com.liteninja.utils
{
    public static class GradientExtensions
    {
        public static Gradient Clone(this Gradient target)
        {
            var newGradient = new Gradient
            {
                alphaKeys = target.alphaKeys,
                colorKeys = target.colorKeys,
                mode = target.mode
            };

            return newGradient;
        }
    }
}