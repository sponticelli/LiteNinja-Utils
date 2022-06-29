using System.Collections.Generic;

namespace LiteNinja.Utils.Generators
{
    public class RepeatGenerator<T> : AGenerator<T>
    {
        private readonly IEnumerable<T> _values;
        private readonly IEnumerator<T> _iterator;

        public RepeatGenerator(IEnumerable<T> values)
        {
            _values = values;
            _iterator = _values.GetEnumerator();

            NextValue();
        }
        public override T NextValue()
        {
            if (!_iterator.MoveNext())
            {
                _iterator.Reset();
                _iterator.MoveNext();
            }
            _currentValue = _iterator.Current;
            return _currentValue;
        }

        public override IGenerator<T> Clone()
        {
            return new RepeatGenerator<T>(_values);
        }

        public override void Reset()
        {
            _iterator.Reset();
            NextValue();
            _currentValue = _iterator.Current;
        }
    }
}