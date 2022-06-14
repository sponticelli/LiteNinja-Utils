using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace com.liteninja.utils
{
    public static class IListExtensions
    {
        public static bool HasIndex<T>(this IList<T> self, int index)
        {
            return index.IsInRangeInclusive(0, self.Count - 1);
        }

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

        public static void RemoveNullEntries<T>(this IList<T> list) where T : class
        {
            for (var i = list.Count - 1; i >= 0; i--)
                if (Equals(list[i], null))
                    list.RemoveAt(i);
        }


        public static void RemoveDefaultValues<T>(this IList<T> self)
        {
            for (var i = self.Count - 1; i >= 0; i--)
                if (Equals(default(T), self[i]))
                    self.RemoveAt(i);
        }
        
        public static void Swap<T>(this IList<T> list, int firstIndex, int secondIndex)
        {
            if (list == null || list.Count < 2) return;
            (list[firstIndex], list[secondIndex]) = (list[secondIndex], list[firstIndex]);
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            for (var i = 0; i < list.Count; i++)
            {
                var randomIndex = Random.Range(i, list.Count);
                Swap(list, randomIndex, i);
            }
        }

        public static void Shuffle<T>(this IList<T> list, int seed)
        {
            var state = Random.state;
            Random.InitState(seed);
            Shuffle(list);
            Random.state = state;
        }

        public static void RotateLeft<T>(this IList<T> list, int count = 1)
        {
            if (list == null || list.Count < 2)
                return;

            for (var current = 0; current < count; current++)
            {
                var first = list[0];
                list.RemoveAt(0);
                list.Add(first);
            }
        }
        
        public static void RotateRight<T>(this IList<T> list, int count = 1)
        {
            if (list == null || list.Count < 2)
                return;

            var lastIndex = list.Count - 1;
            for (var current = 0; current < count; current++)
            {
                var last = list[lastIndex];
                list.RemoveAt(lastIndex);
                list.Insert(0, last);
            }
        }
        
        
        
    }
}