namespace LiteNinja.Utils.Generators
{
    public interface IGenerator
    {
        // The last generated value.
        object CurrentValue { get; }

        // Generate the next value.
        object NextValue();
        
        void Reset();
        
        IGenerator Clone();
    }
    
    public interface IGenerator<out T> : IGenerator
    {
        new T CurrentValue { get; }
        new T NextValue();
        
        new IGenerator<T> Clone();
    }
    
    public interface IGenerator<out T, in TArg> : IGenerator
    {
        new T CurrentValue { get; }
         T NextValue(TArg arg);
        
        new IGenerator<T, TArg> Clone();
    }
}