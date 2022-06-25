using System;
using System.Collections.Generic;

namespace LiteNinja.Utils
{
    public class LazyValueDictionary<TKey, TValue> : LazyDictionaryBase<TKey, TValue> where TValue : struct
    {

        private readonly Dictionary<TKey, Provider> _values = new Dictionary<TKey, Provider>();
        public void Add(TKey key, Func<TValue> factory)
        {
            if (key == null)
                throw new NullReferenceException(nameof(key));

            if (factory == null)
                throw new NullReferenceException(nameof(factory));

            _values.Add(key, new Provider(factory));
        }
        
        protected override TValue GetValue(TKey key) => _values[key].Value;
        
        private class Provider
        {
            private TValue? _nullableValue;
            private readonly Func<TValue> _factory;
            
            public TValue Value => _nullableValue ?? (_nullableValue = _factory()).Value;
            public Provider(Func<TValue> factory) => _factory = factory;
        }
    }
}
