using System;
using System.Collections.Generic;

namespace LiteNinja.Utils
{
    public abstract class LazyDictionaryBase<TKey, TValue>
    {
        public TValue this[TKey key]
        {
            get
            {
                try
                {
                    return GetValue(key);
                }
                catch (Exception e)
                {
                    throw new KeyNotFoundException($"Failed returning item for key {key}.", e);
                }
            }
        }
        
        protected abstract TValue GetValue(TKey key);
    }
}
