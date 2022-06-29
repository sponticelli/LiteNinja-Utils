using System;
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

        
        /// <summary>
        /// Throw a NullReferenceException if the object is null.
        /// </summary>
        public static T ThrowIfNull<T>(this T self, string message = null) where T : class
        {
            if (self == null)
            {
                throw new NullReferenceException(message ?? "Object is null.");
            }

            return self;
        }
    }
}