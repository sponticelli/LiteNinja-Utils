using System;

namespace LiteNinja.Utils.Extensions
{
    public static class SystemRandomExtensions
    {
        /// <summary>
        /// Generates normally distributed random numbers.
        /// </summary>
        public static double NextGaussian(this Random self)
        {
            double u;
            double s;
            do
            {
                u = 2 * self.NextDouble() - 1;
                var v = 2 * self.NextDouble() - 1;
                s = u * u + v * v;
            } while (s is >= 1 or 0);
            return u * Math.Sqrt(-2 * Math.Log(s) / s);
        }
        
        /// <summary>
        /// Generates values from a triangular distribution.
        /// @see http://en.wikipedia.org/wiki/Triangular_distribution
        /// </summary>
        public static double NextTriangular(this Random self, double min, double max)
        {
            var u = self.NextDouble();
            return min + (max - min) * (u < 0.5 ? 2 * u * u : (4 - 2 * u) * u);
        }
        
    }
}