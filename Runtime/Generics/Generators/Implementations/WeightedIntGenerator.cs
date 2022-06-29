using System;
using System.Linq;
using LiteNinja.Utils.Extensions;

namespace LiteNinja.Utils.Generators
{
    /// <summary>
    /// A generator that generates integers given an arbitrary distribution.
    /// </summary>
    public class WeightedIntGenerator : AGenerator<int>
    {
        private readonly float[] _weights;
        private readonly float _totalWeight;
        private readonly int[] _values;
        private readonly int _seed;
        private  Random _random;
        private bool _hasSeed;

        public WeightedIntGenerator(int seed, int[] values,  float[] weights)
        {
            _weights = weights;
            _totalWeight = _weights.Sum();
            
            if (values.Length != weights.Length)
                throw new ArgumentException("The number of values and weights must be the same.");
            
            _values = values;
            
            _seed = seed;
            _hasSeed = true;
            _random = new Random(seed);
        }
        
        public WeightedIntGenerator(int[] values, float[] weights) : this((int)DateTime.UnixEpoch.Ticks, values, weights)
        {
            _hasSeed = false;
        }

        public override int NextValue()
        {
            // Get a random number between 0 and the total weight.
            var random = (float) _random.NextDouble() * _totalWeight;
            // find index of the random number in the weights array.
            
            var index = 0;
            var sum = _weights[index];
            while (!random.Approximately(sum) && index < _weights.Length)
            {
                index++;
                sum += _weights[index];
            }
            
            _currentValue = _values[index];
            return _currentValue;
        }

        public override IGenerator<int> Clone()
        {
            return _hasSeed ? new WeightedIntGenerator(_seed, _values, _weights) : new WeightedIntGenerator(_values, _weights);
        }

        public override void Reset()
        {
            _random = new Random(_seed);
        }
    }
}