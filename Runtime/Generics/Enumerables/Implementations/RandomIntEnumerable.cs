using System;


namespace LiteNinja.Utils.Generics.Enumerables
{
    /// <summary>
    /// Generator that create random integer between min and max inclusive with an uniform distribution.
    /// </summary>
    public class RandomIntEnumerable : FuncEnumerable<int>
    {
        public RandomIntEnumerable(Random random, int min, int max) : base(() => (random.Next(min, max + 1), true))
        {
        }
        
    }
    

}