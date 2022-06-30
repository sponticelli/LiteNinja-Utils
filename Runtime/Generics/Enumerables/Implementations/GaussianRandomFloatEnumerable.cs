using System;
using LiteNinja.Utils.Extensions;
using LiteNinja.Utils.Helpers;

namespace LiteNinja.Utils.Generics.Enumerables
{
    public class GaussianRandomFloatEnumerable : FuncEnumerable<float>
    {
        public GaussianRandomFloatEnumerable(Random random) : base(() => ((float)random.NextGaussian(),  true))
        {
        }
        
        public GaussianRandomFloatEnumerable() : base(() => (UnityRandomHelper.NextGaussian(), true))
        {
        }

    }
}