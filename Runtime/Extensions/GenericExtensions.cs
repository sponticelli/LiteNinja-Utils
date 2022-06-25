using System.Linq;

namespace LiteNinja.Utils.Extensions
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

        public static T ReplaceIf<T>(this T self, T value, T newValue = default)
        {
            return self.Equals(value) ? newValue : self;
        }

    }
}