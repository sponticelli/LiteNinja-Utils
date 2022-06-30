using System;
using System.Collections;
using System.Collections.Generic;

namespace LiteNinja.Utils.Generics.Enumerables
{
    public class IterateEnumerator<T> : IEnumerator<T>
    {
        private readonly Func<T, (T, bool)> _generator;
        private T _currentValue;
        private readonly T _defaultValue;
        private bool _hasValue;

        
        public IterateEnumerator(Func<T, (T, bool)> generator, T defaultValue = default(T))
        {
            _generator = generator;
            _currentValue = defaultValue;
            _defaultValue = defaultValue;
        }

        public bool MoveNext()
        {
            (_currentValue, _hasValue) = _generator(_currentValue);
            return _hasValue;
        }

        public void Reset()
        {
            _currentValue = _defaultValue;
            _hasValue = false;
        }

        public T Current => _hasValue ? _currentValue : throw new InvalidOperationException();

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}