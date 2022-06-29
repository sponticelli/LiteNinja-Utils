namespace LiteNinja.Utils.Generators
{
    /// <summary>
    /// A generator that generates consecutive integers starting from a min value to a max value, and repeats the cycle.
    /// </summary>
    public class CountGenerator : AGenerator<int>
    {
        private readonly int _upperLimit;
        private readonly int _lowerLimit;

        public CountGenerator(int min, int max)
        {
            // if min is greater than max, swap them
            if (min > max)
            {
                (min, max) = (max, min);
            }
            _upperLimit = max;
            _lowerLimit = min;
            
            _currentValue = _lowerLimit;
        }



        public override int NextValue()
        {
            if (_currentValue == _upperLimit)
            {
                _currentValue = _lowerLimit;
            }
            else
            {
                _currentValue++;
            }
            return _currentValue;
        }

        public override IGenerator<int> Clone()
        {
            return new CountGenerator(_lowerLimit, _upperLimit);
        }

        public override void Reset()
        {
            _currentValue = _lowerLimit;
        }
    }
}