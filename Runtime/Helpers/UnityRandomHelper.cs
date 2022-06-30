using UnityEngine;

namespace LiteNinja.Utils.Helpers
{
    public static class UnityRandomHelper
    {
        /// <summary>
        /// Generates normally distributed random numbers.
        /// </summary>
        public static float NextGaussian()
        {
            float u;
            float s;
            do
            {
                u = 2 * Random.value - 1;
                var v = 2 * Random.value - 1;
                s = u * u + v * v;
            } while (s is >= 1 or 0);

            return u * Mathf.Sqrt(-2 * Mathf.Log(s) / s);
        }
        
        /// <summary>
        /// Generates values from a triangular distribution.
        /// @see http://en.wikipedia.org/wiki/Triangular_distribution
        /// </summary>
        public static float NextTriangular(float min, float max)
        {
            var u = Random.value;
            return min + (max - min) * (u < 0.5 ? 2 * u * u : (4 - 2 * u) * u);
        }
        
    }
}