using System;
using System.Collections;
using System.Collections.Generic;

namespace LiteNinja.Utils.Generics.Enumerables
{
    public class FuncEnumerable<T> : IEnumerable<T>
    {

        protected Func<(T, bool)> _generator;
        protected T _defaultValue;


        public FuncEnumerable(Func<(T, bool)> generator, T defaultValue = default(T))
        {
            _generator = generator;
            _defaultValue = defaultValue;
        }
        

        public virtual IEnumerator<T> GetEnumerator()
        {
            return new FuncEnumerator<T>(_generator, _defaultValue);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}