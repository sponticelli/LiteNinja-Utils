using UnityEngine;

namespace LiteNinja.Utils.Extensions
{
    public static class Vector3IntExtensions
    {
        public static Vector2Int ToVector2IntXZ(this Vector3Int self)
        {
            return new Vector2Int(Mathf.RoundToInt(self.x), Mathf.RoundToInt(self.z));
        }

        public static Vector2Int ToVector2IntXY(this Vector3Int self)
        {
            return new Vector2Int(Mathf.RoundToInt(self.x), Mathf.RoundToInt(self.y));
        }
        
        public static Vector2Int ToVector2IntYZ(this Vector3Int self)
        {
            return new Vector2Int(Mathf.RoundToInt(self.y), Mathf.RoundToInt(self.z));
        }
        
        
    }
}