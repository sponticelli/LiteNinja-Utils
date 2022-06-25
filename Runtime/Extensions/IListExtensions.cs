using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace LiteNinja.Utils.Extensions
{
    public static class IListExtensions
    {
        public static bool HasIndex<T>(this IList<T> self, int index)
        {
            return index.IsInRangeInclusive(0, self.Count - 1);
        }

        public static void Add<T>(this IList<T> self, T item, int capacity)
        {
            self.Add(item);

            var removeCount = self.Count - capacity;

            if (removeCount > 0)
            {
                RemoveRange(self, 0, removeCount);
            }
        }

        public static void Enqueue<T>(this IList<T> self, T item)
        {
            self.Add(item);
        }

        public static void Enqueue<T>(this IList<T> self, T item, int capacity)
        {
            Add(self, item, capacity);
        }

        public static T Dequeue<T>(this IList<T> self)
        {
            var value = self[0];
            self.RemoveAt(0);
            return value;
        }

        public static T Peek<T>(this IList<T> self)
        {
            return self[0];
        }

        public static void Push<T>(this IList<T> self, T item)
        {
            self.Insert(0, item);
        }

        public static void Push<T>(this IList<T> self, T item, int capacity)
        {
            self.Insert(0, item);

            var listCount = self.Count;
            var removeCount = listCount - capacity;
            var index = listCount - removeCount - 1;

            RemoveRange(self, index, removeCount);
        }

        public static T Pop<T>(this IList<T> self)
        {
            return Dequeue(self);
        }
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

        public static void RemoveNullEntries<T>(this IList<T> self) where T : class
        {
            for (var i = self.Count - 1; i >= 0; i--)
                if (Equals(self[i], null))
                    self.RemoveAt(i);
        }


        public static void RemoveDefaultValues<T>(this IList<T> self)
        {
            for (var i = self.Count - 1; i >= 0; i--)
                if (Equals(default(T), self[i]))
                    self.RemoveAt(i);
        }
        
        public static void Swap<T>(this IList<T> self, int firstIndex, int secondIndex)
        {
            if (self == null || self.Count < 2) return;
            (self[firstIndex], self[secondIndex]) = (self[secondIndex], self[firstIndex]);
        }
        
        public static void Swap<T>(this IList<T> self, T item1, T item2)
        {
            if (!self.Contains(item1))
            {
                throw new ArgumentOutOfRangeException("item1", item1, "List does not contain item1.");
            }

            if (!self.Contains(item2))
            {
                throw new ArgumentOutOfRangeException("item2", item2, "List does not contain item2.");
            }

            var i1 = self.IndexOf(item1);
            var i2 = self.IndexOf(item2);

            self[i1] = item2;
            self[i2] = item1;
        }

        public static void Shuffle<T>(this IList<T> self)
        {
            for (var i = 0; i < self.Count; i++)
            {
                var randomIndex = Random.Range(i, self.Count);
                Swap(self, randomIndex, i);
            }
        }
        
        public static void Shuffle<T>(this IList<T> self, int seed)
        {
            var state = Random.state;
            Random.InitState(seed);
            Shuffle(self);
            Random.state = state;
        }

        public static void Sort<T>(this IList<T> self, Comparison<T> compare, int index = 0, int count = 0)
        {
            if (count <= 0) count = self.Count - index;
            var lastIndex = index + count - 1;
            T temp;

            for (var i = 0; i < count - 1; i++)
            {
                for (var j = index; j < lastIndex; j++)
                {
                    if (compare(self[j], self[j + 1]) <= 0) continue;
                    temp = self[j];
                    self[j] = self[j + 1];
                    self[j + 1] = temp;
                }

                lastIndex--;
            }
        }



        public static void RotateLeft<T>(this IList<T> self, int count = 1)
        {
            if (self == null || self.Count < 2)
                return;

            for (var current = 0; current < count; current++)
            {
                var first = self[0];
                self.RemoveAt(0);
                self.Add(first);
            }
        }
        
        public static void RotateRight<T>(this IList<T> self, int count = 1)
        {
            if (self == null || self.Count < 2)
                return;

            var lastIndex = self.Count - 1;
            for (var current = 0; current < count; current++)
            {
                var last = self[lastIndex];
                self.RemoveAt(lastIndex);
                self.Insert(0, last);
            }
        }
        
        public static int GetNextIndexCircular<T>(this IList<T> self, int currentIndex)
        {
            var count = self.Count;
            return count == 0 ? 0 : (currentIndex + 1) % count;
        }
        
        public static int GetPrevIndexCircular<T>(this IList<T> self, int currentIndex)
        {
            var prevIndex = currentIndex - 1;
            return prevIndex >= 0 ? prevIndex : self.Count - 1;
        }

        public static void RemoveRange<T>(this IList<T> self, int index, int count)
        {
            var removes = self.Skip(index).Take(count);
            self = (IList<T>) self.Except(removes);
        }

        public static IEnumerable<T> Slice<T>(this IList<T> self, int index, int count)
        {
            return self.Skip(index).Take(count);
        }
        
    }
}