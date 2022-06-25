using UnityEngine;

namespace LiteNinja.Utils.Extensions
{
    public static class Color32Extensions
    {
        public static Color32 Clone(this Color32 self)
        {
            return new Color32(self.r, self.g, self.b, self.a);
        }

        
    }
}