namespace LiteNinja.Utils.Generators
{
    public class ConstantGenerator<T> : AGenerator<T>
    {
        public ConstantGenerator(T value)
        {
            _currentValue = value;
        }
        
        public override T NextValue()
        {
            return _currentValue;
        }

        public override IGenerator<T> Clone()
        {
            return new ConstantGenerator<T>(_currentValue);
        }

        public override void Reset()
        {
            // Do Nothing
        }
    }
}