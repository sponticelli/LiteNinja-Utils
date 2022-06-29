using System;

namespace LiteNinja.Utils.Generators
{
    /// <summary>
    /// Generator that create random integer between min and max inclusive with an uniform distribution.
    /// </summary>
    public class RandomIntGenerator : AGenerator<int>
    {
        private Random _random;
        private int _seed;
        private bool _hasSeed;

        private readonly int _lowerBound;
        private readonly int _upperBound;

        public RandomIntGenerator(int min = 0, int max = 1)
        {
            _lowerBound = min;
            _upperBound = max;
            _seed = (int)DateTime.UnixEpoch.Ticks;
            _random = new Random(_seed);
            NextValue();
        }

        public RandomIntGenerator(int seed, int min = 0, int max = 1)
        {
            _lowerBound = min;
            _upperBound = max;
            _seed = seed;
            _random = new Random(seed);

            NextValue();
        }

        public override int NextValue()
        {
            //random int between _lowerBound and _upperBound inclusive
            _currentValue = _random.Next(_lowerBound, _upperBound + 1);
            return _currentValue;
        }

        public override void Reset()
        {
            if (_hasSeed) _random = new Random(_seed);
            _seed = (int)DateTime.UnixEpoch.Ticks;
            _random = new Random(_seed);
        }

        public override IGenerator<int> Clone()
        {
            return _hasSeed ? new RandomIntGenerator(_seed, _lowerBound, _upperBound) : new RandomIntGenerator(_lowerBound, _upperBound);
        }
    }
}