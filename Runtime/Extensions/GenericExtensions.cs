using System.Linq;

namespace com.liteninja.utils
{
    public static class GenericExtensions
    {
        /// <summary>
        /// Returns true if an object is equal to any of the @values
        /// </summary>
        public static bool IsIn<T>(this T self, params T[] values)
        {
            return values.Any(n => n.Equals(self));
        }
    }
}