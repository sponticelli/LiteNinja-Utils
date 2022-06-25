using UnityEngine;

namespace LiteNinja.Utils.Extensions
{
    public static class RectExtensions
    {
        /// <summary>
        /// Returns the position (Vector2) of the Rect's center.
        /// </summary>
        public static Vector2 GetCenter(this Rect self)
        {
            return new Vector2(self.position.x + self.width / 2, self.position.y + self.height / 2);
        }
        
        /// <summary>
        /// Sets rect center.
        /// </summary>
        public static Rect SetCenter(this Rect self, Vector2 center)
        {
            self.center = center;
            return self;
        }

        /// <summary>
        /// Create a new Rect copied from self but adding x to the rect's x
        /// </summary>
        public static Rect AddX(this Rect self, float x)
        {
            return self.SetX(self.x + x);
        }

        /// <summary>
        /// Create a new Rect copied from self but adding y to the rect's y
        /// </summary>
        public static Rect AddY(this Rect self, float y)
        {
            return self.SetY(self.y + y);
        }

        /// <summary>
        /// Create a new Rect copied from self but adding width to the rect's width
        /// </summary>
        public static Rect AddWidth(this Rect self, float width)
        {
            return self.SetWidth(self.width + width);
        }

        /// <summary>
        /// Create a new Rect copied from self but adding height to the rect's height
        /// </summary>
        public static Rect AddHeight(this Rect self, float height)
        {
            return self.SetHeight(self.height + height);
        }

        /// <summary>
        /// Create a new Rect copied from self but the x
        /// </summary>
        public static Rect SetX(this Rect self, float x)
        {
            return new Rect(x, self.y, self.width, self.height);
        }

        /// <summary>
        /// Create a new Rect copied from self but the y
        /// </summary>
        public static Rect SetY(this Rect self, float y)
        {
            return new Rect(self.x, y, self.width, self.height);
        }

        /// <summary>
        /// Create a new Rect copied from self but the width
        /// </summary>
        public static Rect SetWidth(this Rect self, float width)
        {
            return new Rect(self.x, self.y, width, self.height);
        }

        /// <summary>
        /// Create a new Rect copied from self but the height
        /// </summary>
        public static Rect SetHeight(this Rect self, float height)
        {
            return new Rect(self.x, self.y, self.width, height);
        }
        
        /// <summary>
        /// Sets rect position
        /// </summary>
        public static Rect SetPosition(this Rect self, Vector2 position)
        {
            self.position = position;
            return self;
        }
        public static void Encapsulate(this ref Rect rect, Vector2 point)
        {
            if (rect.xMin > point.x) rect.xMin = point.x;
            if (rect.xMax < point.x) rect.xMax = point.x;
            if (rect.yMin > point.y) rect.yMin = point.y;
            if (rect.yMax < point.y) rect.yMax = point.y;
        }
        
        public static Rect GetIntersection(this Rect rect, Rect other)
        {
            if (rect.xMin > other.xMin) other.xMin = rect.xMin;
            if (rect.xMax < other.xMax) other.xMax = rect.xMax;
            if (rect.yMin > other.yMin) other.yMin = rect.yMin;
            if (rect.yMax < other.yMax) other.yMax = rect.yMax;
            return other;
        }
    }

    
}