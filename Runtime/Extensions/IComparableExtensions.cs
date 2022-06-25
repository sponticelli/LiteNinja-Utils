using System;

namespace LiteNinja.Utils.Extensions
{
    public static class IComparableExtensions
    {
        /// <summary>
        /// Checks if the object is on the specified interval. 
        /// </summary>
        public static bool IsBetween<T>(this T self, T a, T b, bool aInclusive = true, bool bInclusive = true)
            where T : IComparable
        {
            if (a.CompareTo(b) != 1)
                return (aInclusive ? self.CompareTo(a).EqualsToAny(0, 1) : self.CompareTo(a) == 1) &&
                       (bInclusive ? self.CompareTo(b).EqualsToAny(-1, 0) : self.CompareTo(b) == -1);
            (a, b) = (b, a);
            (aInclusive, bInclusive) = (bInclusive, aInclusive);

            return (aInclusive ? self.CompareTo(a).EqualsToAny(0, 1) : self.CompareTo(a) == 1) &&
                   (bInclusive ? self.CompareTo(b).EqualsToAny(-1, 0) : self.CompareTo(b) == -1);
        }
    }
}