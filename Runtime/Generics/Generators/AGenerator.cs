namespace LiteNinja.Utils.Generators
{
    public abstract class AGenerator<T> : IGenerator<T>
    {
        protected T _currentValue;

        public  T CurrentValue => _currentValue;
        object IGenerator.CurrentValue => CurrentValue;

        public abstract T NextValue();
        

        object IGenerator.NextValue()
        {
            return NextValue();
        }

        public abstract void Reset();

        public abstract IGenerator<T> Clone();

        IGenerator IGenerator.Clone()
        {
            return Clone();
        }
    }
}