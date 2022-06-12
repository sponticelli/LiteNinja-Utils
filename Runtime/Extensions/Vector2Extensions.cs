using UnityEngine;

namespace com.liteninja.utils
{
    public static class Vector2Extensions
    {
        public static Vector2 FaceDirection(this Vector2 self, Vector2 direction)
        {
            var tangent = direction.x == 0
                ? direction.y >= 0 ? float.MaxValue : float.MinValue
                : direction.y / direction.x;
            var angle = Mathf.Atan(tangent).Rad2Deg();
            if (direction.x < 0) angle += 180;

            return self.RotateToAngle(angle.Deg2Rad());
        }

        public static Vector2 RotateToAngle(this Vector2 self, float angle)
        {
            return Quaternion.AngleAxis(angle.Rad2Deg(), new Vector3(0, 0, 1)) * self;
        }

        /// <summary>
        /// Gets max component from vector.
        /// </summary>
        public static float MaxComponent(this Vector2 self) => Mathf.Max(self.x, self.y);

        /// <summary>
        /// Gets min component from vector.
        /// </summary>
        public static float MinComponent(this Vector2 self) => Mathf.Min(self.x, self.y);

        /// <summary>
        /// Remaps all vector's components from one interval to other.
        /// </summary>
        public static Vector2 Remap(this Vector2 self, float sourceMin, float sourceMax, float targetMin,
            float targetMax)
        {
            return new Vector2(self.x.Remap(sourceMin, sourceMax, targetMin, targetMax),
                self.y.Remap(sourceMin, sourceMax, targetMin, targetMax));
        }
        
        public static Vector2Int ToVector2Int(this Vector2 self)
        {
            return new Vector2Int(Mathf.RoundToInt(self.x), Mathf.RoundToInt(self.y));
        }
        
        public static Vector3 ToVector3X0Y(this Vector2 self)
        {
            return new Vector3(self.x, 0f, self.y);
        }
        
        public static Vector3 x0y(this Vector2 self)
        {
            return new Vector3(self.x, 0f, self.y);
        }
    }
}