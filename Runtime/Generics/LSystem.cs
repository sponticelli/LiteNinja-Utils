using System.Collections.Generic;
using System.Linq;

namespace LiteNinja.Utils
{
    /// <summary>
    /// An implementation of an L-system.
    /// @ref: http://en.wikipedia.org/wiki/L-system
    /// </summary>
    public class LSystem<T>
    {
        private readonly Dictionary<T, List<T>> _rules;
        private readonly List<T> _axiom;

        public LSystem()
        {
            _rules = new Dictionary<T, List<T>>();
        }

        public LSystem(Dictionary<T, List<T>> rules)
        {
            _rules = rules;
        }

        public LSystem(IEqualityComparer<T> comparer)
        {
            _rules = new Dictionary<T, List<T>>(comparer);
        }

        public void AddRule(T symbol, List<T> rule)
        {
            _rules[symbol] = rule;
        }
        
        public void AddRule(T symbol, IEnumerable<T> rule)
        {
            AddRule(symbol, rule.ToList());
        }

        public void AddRule(T symbol, params T[] rule)
        {
            AddRule(symbol, new List<T>(rule));
        }
        
        public void AddRule(T symbol, T rule)
        {
            AddRule(symbol, new List<T> {rule});
        }
        
        
        public IEnumerable<T> Process(IEnumerable<T> input)
        {
            var output = new List<T>();
            foreach (var symbol in input)
            {
                if (_rules.ContainsKey(symbol))
                {
                    output.AddRange(_rules[symbol]);
                }
                else
                {
                    output.Add(symbol);
                }
            }
            return output;
        }
        
        public IEnumerable<T> Process(T[] input)
        {
            return Process(new List<T>(input));
        }
        
        public IEnumerable<T> Process(IEnumerable<T> input, int iterations)
        {
            var output = input;
            for (var i = 0; i < iterations; i++)
            {
                output = Process(output);
            }
            return output;
        }
        
        public IEnumerable<T> Process(T[] input, int iterations)
        {
            return Process(new List<T>(input), iterations);
        }
    }
}