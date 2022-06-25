using UnityEngine;

namespace LiteNinja.Utils.Extensions
{
    public static class AnimationCurveExtensions
    {
        public static AnimationCurve Clone(this AnimationCurve self)
        {
            var newCurve = new AnimationCurve(self.keys)
            {
                postWrapMode = self.postWrapMode, preWrapMode = self.preWrapMode
            };
            return newCurve;
        }
    }
}