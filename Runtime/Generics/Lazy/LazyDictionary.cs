using System;
using System.Collections.Generic;

namespace com.liteninja.utils
{
    public class LazyDictionary<TKey, TValue> : LazyDictionaryBase<TKey, TValue> where TValue : class
    {
        private readonly Dictionary<TKey, Provider> _values = new Dictionary<TKey, Provider>();

        public void Add(TKey key, Func<TValue> factory)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            _values.Add(key, new Provider(factory));
        }

        protected override TValue GetValue(TKey key) => _values[key].Value;

        private class Provider
        {
            private TValue _value;
            private readonly Func<TValue> _factory;
            public TValue Value => _value ??= _factory();
            public Provider(Func<TValue> factory) => _factory = factory;
        }
    }
}