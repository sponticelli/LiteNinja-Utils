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

        public static float ScreenToWorldSize(this Camera self, float pixelSize, float clipPlane)
        {
            if (self.orthographic)
            {
                return pixelSize * self.orthographicSize * 2f / self.pixelHeight;
            }

            return pixelSize * clipPlane * Mathf.Tan(self.fieldOfView * 0.5f * Mathf.Deg2Rad) * 2f /
                   self.pixelHeight;
        }

        public static float WorldToScreenSize(this Camera self, float worldSize, float clipPlane)
        {
            if (self.orthographic)
            {
                return worldSize * self.pixelHeight * 0.5f / self.orthographicSize;
            }

            return worldSize * self.pixelHeight * 0.5f /
                   (clipPlane * Mathf.Tan(self.fieldOfView * 0.5f * Mathf.Deg2Rad));
        }

        public static Vector4 GetClipPlane(this Camera self, Vector3 point, Vector3 normal)
        {
            var wtoc = self.worldToCameraMatrix;
            point = wtoc.MultiplyPoint(point);
            normal = wtoc.MultiplyVector(normal).normalized;

            return new Vector4(normal.x, normal.y, normal.z, -Vector3.Dot(point, normal));
        }

        public static Vector4 GetZBufferParams(this Camera self)
        {
            double f = self.farClipPlane;
            double n = self.nearClipPlane;

            var rn = 1f / n;
            var rf = 1f / f;
            var fpn = f / n;

            return SystemInfo.usesReversedZBuffer
                ? new Vector4((float)(fpn - 1.0), 1f, (float)(rn - rf), (float)rf)
                : new Vector4((float)(1.0 - fpn), (float)fpn, (float)(rf - rn), (float)rn);
        }
    }
}