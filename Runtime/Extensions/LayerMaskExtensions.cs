using UnityEngine;

namespace com.liteninja.utils
{
    public static class LayerMaskExtensions
    {
        /// <summary>
        /// Returns if the LayerMask includes the layer value.
        /// </summary>
        public static bool IncludesLayer(this LayerMask self, int layer)
        {
            return ((1 << layer) & self.value) != 0;
        }
    }
}