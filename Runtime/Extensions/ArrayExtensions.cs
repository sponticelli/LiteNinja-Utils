using System;
using System.Collections.Generic;

namespace com.liteninja.utils
{
    public static class ArrayExtensions
    {
        public static void Add<T>(this T[] self, T value)
        {
            Array.Resize(ref self, self.Length + 1);
            self[^1] = value;
        }

        public static T[] Append<T>(this T[] self, params T[] items)
        {
            if (self == null)
            {
                return items;
            }

            var result = new T[self.Length + items.Length];
            self.CopyTo(result, 0);
            items.CopyTo(result, self.Length);
            return result;
        }

        public static void AddRange<T>(this T[] self, int count, IEnumerable<T> values)
        {
            var startCount = self.Length;
            Array.Resize(ref self, self.Length + count);

            foreach (var value in values)
            {
                self[startCount++] = value;
            }
        }

        public static void RemoveAt<T>(this T[] self, int index)
        {
            if (index == self.Length - 1)
            {
                Array.Resize(ref self, index);
                return;
            }

            var result = new T[self.Length - 1];
            if (index != 0)
            {
                Array.Copy(self, 0, result, 0, index);
            }

            Array.Copy(self, index + 1, result, index, self.Length - index - 1);
            self = result;
        }

        public static void Remove<T>(this T[] self, T value)
        {
            self.RemoveAt(Array.IndexOf(self, value));
        }

        public static bool HasIndex<T>(this T[] self, int index)
        {
            return index.IsInRangeInclusive(0, self.Length - 1);
        }
    }
}