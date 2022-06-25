using UnityEngine;

namespace LiteNinja.Utils.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 ToVector3XZY(this Vector3 vec3)
        {
            return new Vector3(vec3.x, vec3.z, vec3.y);
        }

        public static Vector3Int ToVector3Int(this Vector3 self)
        {
            return new Vector3Int(Mathf.RoundToInt(self.x), Mathf.RoundToInt(self.y), Mathf.RoundToInt(self.z));
        }

        public static Vector2Int ToVector2IntXZ(this Vector3 self)
        {
            return new Vector2Int(Mathf.RoundToInt(self.x), Mathf.RoundToInt(self.z));
        }

        public static Vector2Int ToVector2IntXY(this Vector3 self)
        {
            return new Vector2Int(Mathf.RoundToInt(self.x), Mathf.RoundToInt(self.y));
        }

        public static Vector3 SetX(this Vector3 vector, float x)
        {
            return new Vector3(x, vector.y, vector.z);
        }

        public static Vector3 SetY(this Vector3 vector, float y)
        {
            return new Vector3(vector.x, y, vector.z);
        }

        public static Vector3 SetZ(this Vector3 vector, float z)
        {
            return new Vector3(vector.x, vector.y, z);
        }

        public static Vector3 GetPerpendicularDirector(this Vector3 vector)
        {
            var z = vector.x + vector.y / vector.z;
            return new Vector3(1, 1, z).normalized;
        }

        public static float SqrDistance(this Vector3 vector, Vector3 other)
        {
            return (vector - other).sqrMagnitude;
        }

        /// <summary>
        /// Returns a new Vector2 using the given vector's x as x and the y as y
        /// </summary>
        public static Vector2 ToVector2XY(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.y);
        }

        /// <summary>
        /// Returns a new Vector2 using the given vector's x as x and the z as y
        /// </summary>
        public static Vector2 ToVector2XZ(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.z);
        }

        /// <summary>
        /// Gets max component from vector.
        /// </summary>
        public static float MaxComponent(this Vector3 vector) => Mathf.Max(vector.x, vector.y, vector.z);

        /// <summary>
        /// Gets min component from vector.
        /// </summary>
        public static float MinComponent(this Vector3 vector) => Mathf.Min(vector.x, vector.y, vector.z);

        /// <summary>
        /// Remaps all vector's components from one interval to other.
        /// </summary>
        public static Vector3 Remap(this Vector3 vector, float sourceMin, float sourceMax, float targetMin,
            float targetMax)
        {
            return new Vector3(vector.x.Remap(sourceMin, sourceMax, targetMin, targetMax),
                vector.y.Remap(sourceMin, sourceMax, targetMin, targetMax),
                vector.z.Remap(sourceMin, sourceMax, targetMin, targetMax));
        }

        #region Direction

        /// <summary>
        /// Returns if current vector's direction is right
        /// </summary>
        public static bool IsRight(this Vector3 direction, Vector3 right)
        {
            var dotProduct = Vector3.Dot(right, direction.normalized);
            return dotProduct >= Mathf.Cos(45f.Deg2Rad());
        }

        /// <summary>
        /// Returns if current vector's direction is left
        /// </summary>
        public static bool IsLeft(this Vector3 direction, Vector3 right)
        {
            var dotProduct = Vector3.Dot(right, direction.normalized);
            return dotProduct <= Mathf.Cos(135f.Deg2Rad());
        }

        /// <summary>
        /// Returns if current vector's direction is either right or left
        /// </summary>
        public static bool IsLateral(this Vector3 direction, Vector3 right)
        {
            return direction.IsRight(right) || direction.IsLeft(right);
        }

        /// <summary>
        /// Returns if current vector's direction is forward 
        /// </summary>
        public static bool IsForward(this Vector3 direction, Vector3 forward)
        {
            return direction.IsRight(forward); //same algorithm, only changing 'right' for 'forward'
        }

        /// <summary>
        /// Returns if current vector's direction is backward
        /// </summary>
        public static bool IsBackward(this Vector3 direction, Vector3 forward)
        {
            return direction.IsLeft(forward); //same algorithm, only changing 'right' for 'forward'
        }

        /// <summary>
        /// Returns if current vector's direction is either forward or backward
        /// </summary>
        public static bool IsFrontal(this Vector3 direction, Vector3 forward)
        {
            return direction.IsForward(forward) || direction.IsBackward(forward);
        }

        #endregion
    }
}