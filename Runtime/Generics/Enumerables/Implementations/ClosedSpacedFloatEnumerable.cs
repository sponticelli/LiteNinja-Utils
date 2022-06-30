namespace LiteNinja.Utils.Generics.Enumerables
{
    /// <summary>
    /// A generator that produces evenly spaced floats from min to max, min and max included.
    /// </summary>
    public class ClosedSpacedFloatEnumerable : FuncEnumerable<float>
    {
        private readonly float _upperLimit;
        private readonly float _lowerLimit;
        private readonly float _step;
        private float _currentValue;

        public ClosedSpacedFloatEnumerable(float min, float max, int samples) : base(null)
        {
            if (min > max)
            {
                (min, max) = (max, min);
            }

            _upperLimit = max;
            _lowerLimit = min;
            _step = (max - min) / samples;


            _currentValue = _lowerLimit - _step;

            _generator = () =>
            {
                var isDone = _currentValue > _upperLimit;
                if (!isDone)
                {
                    _currentValue += _step;
                }

                return (_currentValue, isDone);
            };
            _defaultValue = _currentValue;
        }
    }
}