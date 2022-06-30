using System;
using System.Collections;
using System.Collections.Generic;

namespace LiteNinja.Utils.Generics.Enumerables
{
    public class IterateEnumerable<T> : IEnumerable<T>
    {
        protected Func<T, (T, bool)> _generator;
        protected  T _defaultValue;

        public IterateEnumerable(Func<T, (T, bool)> generator, T defaultValue = default(T))
        {
            _generator = generator;
            _defaultValue = defaultValue;
        }
        
        
        public IEnumerator<T> GetEnumerator()
        {
            return new IterateEnumerator<T>(_generator, _defaultValue);;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}