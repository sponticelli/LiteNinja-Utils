using System;
using System.Collections.Generic;
using System.Linq;
using UnityRandom = UnityEngine.Random;

namespace LiteNinja.Utils.Extensions
{
    public static class ListExtensions
    {
        public static T GetRandomItem<T>(this List<T> self)
        {
            var random = UnityRandom.Range(0, self.Count);
            return self[random];
        }

        /// <summary>
        /// Replace the specified self, src and func.
        /// </summary>
        public static void Replace<TSource>(this List<TSource> self, IEnumerable<TSource> src, Func<TSource, TSource, bool> func)
        {
            if (func == null) return;
            var enumerable = src as TSource[] ?? src.ToArray();
            var adds = enumerable.Where(x => !self.Any(y => func(x, y)));
            var removes = self.Where(x => !enumerable.Any(y => func(x, y)));
            adds.ForEach(self.Add);
            removes.ForEach(x => self.Remove(x));
        }

        /// <summary>
        /// Clears the with add range.
        /// </summary>
        public static void ClearWithAddRange<TSource>(this List<TSource> self, IEnumerable<TSource> adds)
        {
            if (adds == null) return;
            self.Clear();
            self.AddRange(adds);
        }

        /// <summary>
        /// Remove the specified self and func.
        /// </summary>
        public static void Remove<TSource>(this List<TSource> self, Func<TSource, bool> func)
        {
            if (func == null) return;
            IEnumerable<TSource> remove = self.Where(func).ToList();
            remove.ForEach(x => self.Remove(x));
        }
        
        public static void Resize<T>(this List<T> self, int newSize, T newValue = default)
        {
            if (self.Count == newSize) return;
            if (self.Count > newSize)
            {
                self.RemoveRange(newSize, self.Count - newSize);
            }
            else
            {
                var addCount = newSize - self.Count;

                while (addCount > 0)
                {
                    self.Add(newValue);
                    addCount--;
                }
            }
        }
    }
}