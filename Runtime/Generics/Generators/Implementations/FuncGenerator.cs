using System;

namespace LiteNinja.Utils.Generators
{
    public class FuncGenerator<T> : AGenerator<T>
    {
        private readonly Func<T> _generator;

        public FuncGenerator(Func<T> generator)
        {
            _generator = generator;

            NextValue();
        }

        public override T NextValue()
        {
            _currentValue = _generator();
            return _currentValue;
        }

        public override IGenerator<T> Clone()
        {
            return new FuncGenerator<T>(_generator);
        }

        public override void Reset()
        {
            // do nothing
        }
    }
}