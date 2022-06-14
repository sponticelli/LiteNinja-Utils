using UnityEngine;

namespace com.liteninja.utils
{
    public static class QuaternionExtensions
    {
        public static bool IsNaN(this Quaternion self)
        {
            return float.IsNaN(self.x) || float.IsNaN(self.y) || float.IsNaN(self.z) || float.IsNaN(self.w);
        }
    }
}