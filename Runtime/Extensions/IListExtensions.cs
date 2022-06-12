using UnityEngine;
using System.Collections.Generic;

namespace com.liteninja.utils
{
    public static class IListExtensions
    {
        /// <summary>
        /// Pops element by index
        /// </summary>
        public static T Pop<T>(this IList<T> self, int index)
        {
            var element = self[index];
            self.RemoveAt(index);

            return element;
        }

        /// <summary>
        /// Pops random element from list
        /// </summary>
        public static T PopRandom<T>(this IList<T> self) => Pop(self, Random.Range(0, self.Count));
    }
}