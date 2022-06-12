using UnityEngine;

namespace com.liteninja.utils
{
    public static class CameraExtensions
    {
        /// <summary>
        /// Returns whether or not the gameObject is visible to the camera.
        /// </summary>
        public static bool IsInFov(this Camera self, GameObject gameObject)
        {
            var viewportPoint = self.WorldToViewportPoint(gameObject.transform.position);
            return viewportPoint.x.IsInRangeExclusive(0, 1) &&
                   viewportPoint.y.IsInRangeExclusive(0, 1) &&
                   viewportPoint.z > 0; //viewport.z has to be greater than 0, otherwise is facing backwards
        }
    }
}