using System.Collections.Generic;

namespace LiteNinja.Utils.Extensions
{
    public static class ICollectionExtensions
    {
        public static bool AddIfNotContains<T>(this ICollection<T> collection, T item)
        {
            if (collection.Contains(item))
            {
                return false;
            }

            collection.Add(item);
            return true;
        }
    }
}