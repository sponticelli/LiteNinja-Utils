using System;
using System.Linq;
using LiteNinja.Utils.Extensions;

namespace LiteNinja.Utils.Generics.Enumerables
{


    /// <summary>
    /// An enumerable that generates integers given an arbitrary distribution.
    /// </summary>
    public class WeightedIntEnumerable : FuncEnumerable<int>
    {
        private readonly float[] _weights;
        private readonly float _totalWeight;
        private readonly int[] _values;
        private readonly int _seed;
        private  Random _random;
        public WeightedIntEnumerable(int[] values,  float[] weights, int? seed) : base(null)
        {
            _weights = weights;
            _totalWeight = _weights.Sum();
            if (values.Length != weights.Length)
                throw new ArgumentException("The number of values and weights must be the same.");
            
            _values = values;
            
            _random = seed.HasValue ? new Random(seed.Value) : new Random();

            _generator = () =>
            {
                var random = (float) _random.NextDouble() * _totalWeight;
                // find index of the random number in the weights array.
                var index = 0;
                var sum = _weights[index];
                while (!random.Approximately(sum) && index < _weights.Length)
                {
                    index++;
                    sum += _weights[index];
                }
                return (_values[index], true);
            };
            
        }
    }




}