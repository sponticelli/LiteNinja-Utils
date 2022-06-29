using System;

namespace LiteNinja.Utils.Generators
{
    public class IterateGenerator<T> : AGenerator<T>
    {
        private readonly T _initialValue;
        private readonly Func<T, T> iterator;
        
        public IterateGenerator(T initialValue, Func<T, T> iterator)
        {
            _initialValue = initialValue;
            this.iterator = iterator;
            _currentValue = initialValue;
        }

        public override T NextValue()
        {
            _currentValue = iterator(_currentValue);
            return _currentValue;
        }

        public override IGenerator<T> Clone()
        {
            return new IterateGenerator<T>(_initialValue, iterator);
        }

        public override void Reset()
        {
            _currentValue = _initialValue;
        }
    }
}