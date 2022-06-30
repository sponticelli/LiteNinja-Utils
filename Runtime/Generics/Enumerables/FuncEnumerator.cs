using System;
using System.Collections;
using System.Collections.Generic;

namespace LiteNinja.Utils.Generics.Enumerables
{
    public class FuncEnumerator<T> : IEnumerator<T>
    {
        private readonly Func<(T, bool)> _generator;
        private T _currentValue;
        private readonly T _defaultValue;
        private bool _hasValue;


        public FuncEnumerator(Func<(T, bool)> generator, T defaultValue = default(T))
        {
            _generator = generator;
            _currentValue = defaultValue;
            _defaultValue = defaultValue;
        }

        public bool MoveNext()
        {
            (_currentValue, _hasValue) = _generator();
            return _hasValue;
        }

        public void Reset()
        {
            _currentValue = _defaultValue;
        }

        public T Current => _hasValue ? _currentValue : throw new InvalidOperationException();

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            // Nothing to do
        }
    }
    
}