using System;

namespace LiteNinja.Utils.Generators
{
    /// <summary>
    /// Generator that create random numbers between min and max inclusive with an uniform distribution.
    /// </summary>
    public class RandomFloatGenerator : AGenerator<float>
    {
        private Random random;
        private int seed;
        private bool hasSeed;

        private readonly float _lowerBound;
        private readonly float _upperBound;


        public RandomFloatGenerator(float min = 0f, float max = 1f)
        {
            _lowerBound = min;
            _upperBound = max;
            seed = (int)DateTime.UnixEpoch.Ticks;
            random = new Random(seed);
            NextValue();
        }

        public RandomFloatGenerator(int seed, float min = 0f, float max = 1f)
        {
            _lowerBound = min;
            _upperBound = max;
            this.seed = seed;
            random = new Random(seed);

            NextValue();
        }


        public override float NextValue()
        {
            //random float between _lowerBound and _upperBound inclusive
            _currentValue = (float)random.NextDouble() * (_upperBound - _lowerBound) + _lowerBound;
            return _currentValue;
        }

        public override void Reset()
        {
            if (hasSeed) random = new Random(seed);
            seed = (int)DateTime.UnixEpoch.Ticks;
            random = new Random(seed);
        }

        public override IGenerator<float> Clone()
        {
            return hasSeed
                ? new RandomFloatGenerator(seed, _lowerBound, _upperBound)
                : new RandomFloatGenerator(_lowerBound, _upperBound);
        }
    }
}