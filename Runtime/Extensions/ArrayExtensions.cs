using System;
using System.Collections.Generic;

namespace com.liteninja.utils
{
    public static class ArrayExtensions
    {
        public static void Add<T>(this T[] values, T value)
        {
            Array.Resize(ref values, values.Length + 1);
            values[^1] = value;
        }

        public static T[] Append<T>(this T[] array, params T[] items)
        {
            if (array == null)
            {
                return items;
            }

            var result = new T[array.Length + items.Length];
            array.CopyTo(result, 0);
            items.CopyTo(result, array.Length);
            return result;
        }

        public static void AddRange<T>(this T[] array, int count, IEnumerable<T> values)
        {
            var startCount = array.Length;
            Array.Resize(ref array, array.Length + count);

            foreach (var value in values)
            {
                array[startCount++] = value;
            }
        }

        public static void RemoveAt<T>(this T[] values, int index)
        {
            if (index == values.Length - 1)
            {
                Array.Resize(ref values, index);
                return;
            }

            var result = new T[values.Length - 1];
            if (index != 0)
            {
                Array.Copy(values, 0, result, 0, index);
            }

            Array.Copy(values, index + 1, result, index, values.Length - index - 1);
            values = result;
        }

        public static void Remove<T>(this T[] values, T value)
        {
            values.RemoveAt(Array.IndexOf(values, value));
        }
    }
}