using System;
using System.Linq;

namespace com.liteninja.utils
{
    public static class IEquatableExtensions
    {
        /// <summary>
        ///  Checks if the value equals to all elements of values array.
        /// </summary>
        public static bool EqualsToAll<T>(this T self, params T[] values) where T : IEquatable<T> =>
            values.All(o => o.Equals(self));

        /// <summary>
        ///  Checks if the value equals to at least one of elements of values array.
        /// </summary>
        public static bool EqualsToAny<T>(this T self, params T[] values) where T : IEquatable<T> =>
            values.Any(o => o.Equals(self));
    }
}