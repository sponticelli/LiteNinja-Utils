namespace LiteNinja.Utils.Generics.Enumerables
{
    /// <summary>
    /// A generator that produces evenly spaced floats from min to max, min included and max excluded, and repeats the result.
    /// </summary>
    public class OpenSpacedFloatEnumerable: FuncEnumerable<float>
    {
        private readonly float _upperLimit;
        private readonly float _lowerLimit;
        private readonly float _step;
        private float _currentValue;

        public OpenSpacedFloatEnumerable(float min, float max, int samples) : base(null)
        {
            if (min > max)
            {
                (min, max) = (max, min);
            }

            _upperLimit = max;
            _lowerLimit = min;
            _step = (max - min) / samples;


            _currentValue = _lowerLimit;

            _generator = () =>
            {
                var isDone = _currentValue >= _upperLimit;
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