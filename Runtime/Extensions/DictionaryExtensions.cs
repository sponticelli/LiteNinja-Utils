using System.Collections.Generic;

namespace LiteNinja.Utils.Extensions
{
    public static class DictionaryExtensions
    {

        public static bool AddIfNotContains<TKey, TValue>(this IDictionary<TKey, TValue> self, TKey key,
            TValue value)
        {
            if (self.ContainsKey(key))
            {
                return false;
            }

            self.Add(key, value);
            return true;
        }
        
        public static bool AddOrSet<TKey, TValue>(this IDictionary<TKey, TValue> self, TKey key, TValue value)
        {
            if (self.ContainsKey(key))
            {
                self[key] = value;
                return false;
            }

            self.Add(key, value);
            return true;
        }
    }
}