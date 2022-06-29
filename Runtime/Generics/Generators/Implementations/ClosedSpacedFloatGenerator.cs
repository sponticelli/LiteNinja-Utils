namespace LiteNinja.Utils.Generators
{
    /// <summary>
    /// A generator that produces evenly spaced floats from min to max, both limits included, and repeats the result.
    /// </summary>
    public class ClosedSpacedFloatGenerator : AGenerator<float>
    {
        private readonly float _upperLimit;
        private readonly float _lowerLimit;
        private readonly float _step;
        private readonly int _samples;

        public ClosedSpacedFloatGenerator(float min, float max, int samples)
        {
            // if min is greater than max, swap them
            if (min > max)
            {
                (min, max) = (max, min);
            }

            _upperLimit = max;
            _lowerLimit = min;
            _step = (max - min) / samples;
            _samples = samples;

            _currentValue = _lowerLimit;
        }


        public override float NextValue()
        {
            _currentValue += _step;
            if (_currentValue > _upperLimit)
            {
                _currentValue = _lowerLimit;
            }

            return _currentValue;
        }

        public override IGenerator<float> Clone()
        {
            return new ClosedSpacedFloatGenerator(_lowerLimit, _upperLimit, _samples);
        }

        public override void Reset()
        {
            _currentValue = _lowerLimit;
        }
    }
}