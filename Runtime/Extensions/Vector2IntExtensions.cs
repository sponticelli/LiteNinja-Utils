using UnityEngine;

namespace LiteNinja.Utils.Extensions
{
    public static class Vector2IntExtensions
    {

        public static Vector3 ToVector3X0Z(this Vector2Int vec2)
        {
            return new Vector3(vec2.x, 0f, vec2.y);
        }

        public static Vector3 ToVector3XY0(this Vector2Int vec2)
        {
            return new Vector3(vec2.x, vec2.y, 0f);
        }

        public static Vector3Int ToVector3IntXY0(this Vector2Int vec2)
        {
            return new Vector3Int(vec2.x, vec2.y, 0);
        }

        public static Vector2Int xx(this Vector2Int a)
        {
            return new Vector2Int(a.x, a.x);
        }

        public static Vector2Int yx(this Vector2Int a)
        {
            return new Vector2Int(a.y, a.x);
        }

        public static Vector2Int yy(this Vector2Int a)
        {
            return new Vector2Int(a.y, a.y);
        }

        public static Vector2Int RelativeTo(this Vector2Int vector, Vector2Int otherNorth)
        {
            if (vector == Vector2Int.zero)
            {
                return Vector2Int.zero;
            }

            if (otherNorth == Vector2Int.down)
            {
                return vector * -1;
            }

            if (otherNorth == Vector2Int.right)
            {
                return Vector2Int.Scale(vector.yx(), new Vector2Int(-1, 1));
            }

            if (otherNorth == Vector2Int.left)
            {
                return Vector2Int.Scale(vector.yx(), new Vector2Int(1, -1));
            }

            return vector;
        }

        public static Vector2Int TransformDirection(this Vector2Int vector, Vector2Int forward)
        {
            if (vector == Vector2Int.zero)
            {
                return Vector2Int.zero;
            }

            if (forward == Vector2Int.down)
            {
                return vector * -1;
            }

            if (forward == Vector2Int.right)
            {
                return Vector2Int.Scale(vector.yx(), new Vector2Int(1, -1));
            }

            if (forward == Vector2Int.left)
            {
                return Vector2Int.Scale(vector.yx(), new Vector2Int(-1, 1));
            }

            return vector;
        }

        public static int GridDistance(this Vector2Int fromVector, Vector2Int toVector)
        {
            return Mathf.RoundToInt(Mathf.Abs(fromVector.x - toVector.x) + 
                                    Mathf.Abs(fromVector.y - toVector.y));
        }
    }
}