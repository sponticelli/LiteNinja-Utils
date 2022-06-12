using System.Linq;

namespace com.liteninja.utils
{
    public static class ObjectExtensions
    {
        /// <summary>
        ///  Checks if the obj equals to all elements of objects array.
        /// </summary>
        public static bool EqualsToAll(this object self, params object[] objects) => objects.All(o => o.Equals(self));

        /// <summary>
        ///  Checks if the value equals to at least one of elements of values array.
        /// </summary>
        public static bool EqualsToAny(this object self, params object[] objects) => objects.Any(o => o.Equals(self));
    }
}