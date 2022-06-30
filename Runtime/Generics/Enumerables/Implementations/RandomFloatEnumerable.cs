using System;

namespace LiteNinja.Utils.Generics.Enumerables
{
    /// <summary>
    /// Generator that create random numbers between min and max inclusive with an uniform distribution.
    /// </summary>
    public class RandomFloatEnumerable : FuncEnumerable<float>
    {
        public RandomFloatEnumerable(Random random) : base(() => (random.Next(),  true))
        {
        }
       
        public RandomFloatEnumerable() : base(() => (UnityEngine.Random.value,  true))
        {
        }
    }
}