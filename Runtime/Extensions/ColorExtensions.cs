using UnityEngine;

namespace LiteNinja.Utils.Extensions
{
    public static class ColorExtensions
    { 
        public static Color Clone(this Color self)
        {
            return new Color(self.r, self.g, self.b, self.a);
        }
        
        
    }
}