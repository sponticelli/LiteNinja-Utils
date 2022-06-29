using System;

namespace LiteNinja.Utils.Generators
{
    /// <summary>
    /// A generator that generates random floats from a gaussian distribution.
    /// </summary>
    public class GaussianRandomFloatGenerator : AGenerator<float>
    {
        private Random random;
        private int seed;
        private bool hasSeed;

        public GaussianRandomFloatGenerator()
        {
            seed = (int)DateTime.UnixEpoch.Ticks;
            random = new Random(seed);
            NextValue();
        }

        public GaussianRandomFloatGenerator(int seed)
        {
            this.seed = seed;
            random = new Random(seed);

            NextValue();
        }

        /// <summary>
        /// @ref https://stackoverflow.com/questions/218060/random-gaussian-variables
        /// </summary>
        public override float NextValue()
        {
            var u1 = 1.0 - random.NextDouble(); //uniform(0,1] random doubles
            var u2 = 1.0 - random.NextDouble(); //uniform(0,1] random doubles
            _currentValue = (float)(Math.Sqrt(-2.0 * Math.Log(u1)) *
                                    Math.Sin(2.0 * Math.PI * u2)); //random normal(0,1)
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
            return hasSeed ? new GaussianRandomFloatGenerator(seed) : new GaussianRandomFloatGenerator();
        }
    }
}