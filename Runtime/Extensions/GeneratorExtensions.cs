using System;
using System.Collections.Generic;
using LiteNinja.Utils.Generators;

namespace LiteNinja.Utils.Extensions
{
    public static class GeneratorExtensions
    {
        public static T Next<T>(this IGenerator<T> self)
        {
            return self.NextValue();
        }
        
        public static T NextValueWhile<T>(this IGenerator<T> self, Func<T, bool> predicate)
        {
            var value = self.CurrentValue;
            while (!predicate(value))
            {
                value = self.NextValue();
            }
            return value;
        }
        
        public static IEnumerable<T> NextWhile<T>(this IGenerator<T> self, Func<T, bool> predicate)
        {
            var values = new List<T>();
            var value = self.CurrentValue;
            while (!predicate(value))
            {
                values.Add(value);
                value = self.NextValue();
            }
            return values;
        }
        
        public static IEnumerable<T> Next<T>(this IGenerator<T> self, int count, Func<T, bool> predicate)
        {
            var values = new List<T>();
            var value = self.CurrentValue;
            while (values.Count < count)
            {
                if (predicate(value))
                {
                    values.Add(value);
                }
                value = self.NextValue();
            }
            return values;
        }
        
        public static IEnumerable<T> Next<T>(this IGenerator<T> self, int count)
        {
            var values = new List<T>();
            var value = self.CurrentValue;
            while (values.Count < count)
            {
                values.Add(value);
                value = self.NextValue();
            }
            return values;
        }
        
        public static void Move<T>(this IGenerator<T> self, int count)
        {
            for (var i = 0; i < count; i++)
            {
                self.NextValue();
            }
        }
        
        public static void MoveWhile<T>(this IGenerator<T> self, Func<T, bool> predicate)
        {
            var value = self.CurrentValue;
            while (!predicate(value))
            {
                value = self.NextValue();
            }
        }

    }
}