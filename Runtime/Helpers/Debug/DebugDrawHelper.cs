using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace LiteNinja.Utils
{
    public static class DebugDrawHelper
    {
        /// <summary>
        /// Draws a debug arrow going from the origin position and along the direction Vector3
        /// </summary>
        public static void Arrow(Vector3 origin, Vector3 direction, Color color)
        {
            const float arrowHeadLength = 0.20f;
            const float arrowHeadAngle = 35.0f;

            Debug.DrawRay(origin, direction, color);
            ArrowEnd(origin, direction, color, arrowHeadLength, arrowHeadAngle);
        }

        /// <summary>
        /// Draws a debug arrow going from the origin position and along the direction Vector3
        /// </summary>
        public static void Arrow(Vector3 origin, Vector3 direction, Color color, float arrowLength,
            float arrowHeadLength = 0.20f, float arrowHeadAngle = 35.0f)
        {
            Debug.DrawRay(origin, direction * arrowLength, color);
            ArrowEnd(origin, direction * arrowLength, color, arrowHeadLength, arrowHeadAngle);
        }

        /// <summary>
        /// Draws a debug cross of the specified size and color at the specified point
        /// </summary>
        public static void Cross(Vector3 spot, float crossSize, Color color)
        {
            var tempOrigin = Vector3.zero;
            var tempDirection = Vector3.zero;

            tempOrigin.x = spot.x - crossSize / 2;
            tempOrigin.y = spot.y - crossSize / 2;
            tempOrigin.z = spot.z;
            tempDirection.x = 1;
            tempDirection.y = 1;
            tempDirection.z = 0;
            Debug.DrawRay(tempOrigin, tempDirection * crossSize, color);

            tempOrigin.x = spot.x - crossSize / 2;
            tempOrigin.y = spot.y + crossSize / 2;
            tempOrigin.z = spot.z;
            tempDirection.x = 1;
            tempDirection.y = -1;
            tempDirection.z = 0;
            Debug.DrawRay(tempOrigin, tempDirection * crossSize, color);
        }

        /// <summary>
        /// Draws the arrow end for DebugDrawArrow
        /// </summary>
        private static void ArrowEnd(Vector3 arrowEndPosition, Vector3 direction, Color color,
            float arrowHeadLength = 0.25f, float arrowHeadAngle = 40.0f)
        {
            if (direction == Vector3.zero)
            {
                return;
            }

            var right = Quaternion.LookRotation(direction) * Quaternion.Euler(arrowHeadAngle, 0, 0) * Vector3.back;
            var left = Quaternion.LookRotation(direction) * Quaternion.Euler(-arrowHeadAngle, 0, 0) * Vector3.back;
            var up = Quaternion.LookRotation(direction) * Quaternion.Euler(0, arrowHeadAngle, 0) * Vector3.back;
            var down = Quaternion.LookRotation(direction) * Quaternion.Euler(0, -arrowHeadAngle, 0) * Vector3.back;

            Debug.DrawRay(arrowEndPosition + direction, right * arrowHeadLength, color);
            Debug.DrawRay(arrowEndPosition + direction, left * arrowHeadLength, color);
            Debug.DrawRay(arrowEndPosition + direction, up * arrowHeadLength, color);
            Debug.DrawRay(arrowEndPosition + direction, down * arrowHeadLength, color);
        }

        /// <summary>
        /// Draws handles to materialize the bounds of an object on screen.
        /// </summary>
        public static void HandlesBounds(Bounds bounds, Color color)
        {
#if UNITY_EDITOR
            var boundsCenter = bounds.center;
            var boundsExtents = bounds.extents;

            var v3FrontTopLeft = new Vector3(boundsCenter.x - boundsExtents.x, boundsCenter.y + boundsExtents.y,
                boundsCenter.z - boundsExtents.z); // Front top left corner
            var v3FrontTopRight = new Vector3(boundsCenter.x + boundsExtents.x, boundsCenter.y + boundsExtents.y,
                boundsCenter.z - boundsExtents.z); // Front top right corner
            var v3FrontBottomLeft = new Vector3(boundsCenter.x - boundsExtents.x, boundsCenter.y - boundsExtents.y,
                boundsCenter.z - boundsExtents.z); // Front bottom left corner
            var v3FrontBottomRight = new Vector3(boundsCenter.x + boundsExtents.x, boundsCenter.y - boundsExtents.y,
                boundsCenter.z - boundsExtents.z); // Front bottom right corner
            var v3BackTopLeft = new Vector3(boundsCenter.x - boundsExtents.x, boundsCenter.y + boundsExtents.y,
                boundsCenter.z + boundsExtents.z); // Back top left corner
            var v3BackTopRight = new Vector3(boundsCenter.x + boundsExtents.x, boundsCenter.y + boundsExtents.y,
                boundsCenter.z + boundsExtents.z); // Back top right corner
            var v3BackBottomLeft = new Vector3(boundsCenter.x - boundsExtents.x, boundsCenter.y - boundsExtents.y,
                boundsCenter.z + boundsExtents.z); // Back bottom left corner
            var v3BackBottomRight = new Vector3(boundsCenter.x + boundsExtents.x, boundsCenter.y - boundsExtents.y,
                boundsCenter.z + boundsExtents.z); // Back bottom right corner


            Handles.color = color;

            Handles.DrawLine(v3FrontTopLeft, v3FrontTopRight);
            Handles.DrawLine(v3FrontTopRight, v3FrontBottomRight);
            Handles.DrawLine(v3FrontBottomRight, v3FrontBottomLeft);
            Handles.DrawLine(v3FrontBottomLeft, v3FrontTopLeft);

            Handles.DrawLine(v3BackTopLeft, v3BackTopRight);
            Handles.DrawLine(v3BackTopRight, v3BackBottomRight);
            Handles.DrawLine(v3BackBottomRight, v3BackBottomLeft);
            Handles.DrawLine(v3BackBottomLeft, v3BackTopLeft);

            Handles.DrawLine(v3FrontTopLeft, v3BackTopLeft);
            Handles.DrawLine(v3FrontTopRight, v3BackTopRight);
            Handles.DrawLine(v3FrontBottomRight, v3BackBottomRight);
            Handles.DrawLine(v3FrontBottomLeft, v3BackBottomLeft);
#endif
        }

        public static void SolidRectangle(Vector3 position, Vector3 size, Color borderColor, Color solidColor)
        {
#if UNITY_EDITOR

            var halfSize = size / 2f;

            var verts = new Vector3[4];
            verts[0] = new Vector3(halfSize.x, halfSize.y, halfSize.z);
            verts[1] = new Vector3(-halfSize.x, halfSize.y, halfSize.z);
            verts[2] = new Vector3(-halfSize.x, -halfSize.y, halfSize.z);
            verts[3] = new Vector3(halfSize.x, -halfSize.y, halfSize.z);
            Handles.DrawSolidRectangleWithOutline(verts, solidColor, borderColor);

#endif
        }


        /// <summary>
        /// Draws a cube at the specified position, and of the specified color and size
        /// </summary>
        public static void Cube(Vector3 position, Color color, Vector3 size)
        {
            var halfSize = size / 2f;

            var points = new[]
            {
                position + new Vector3(halfSize.x, halfSize.y, halfSize.z),
                position + new Vector3(-halfSize.x, halfSize.y, halfSize.z),
                position + new Vector3(-halfSize.x, -halfSize.y, halfSize.z),
                position + new Vector3(halfSize.x, -halfSize.y, halfSize.z),
                position + new Vector3(halfSize.x, halfSize.y, -halfSize.z),
                position + new Vector3(-halfSize.x, halfSize.y, -halfSize.z),
                position + new Vector3(-halfSize.x, -halfSize.y, -halfSize.z),
                position + new Vector3(halfSize.x, -halfSize.y, -halfSize.z),
            };

            Debug.DrawLine(points[0], points[1], color);
            Debug.DrawLine(points[1], points[2], color);
            Debug.DrawLine(points[2], points[3], color);
            Debug.DrawLine(points[3], points[0], color);
        }


        /// <summary>
        /// Draws a rectangle based on a Rect and color
        /// </summary>
        public static void Rectangle(Rect rectangle, Color color)
        {
            var pos = new Vector3(rectangle.x + rectangle.width / 2, rectangle.y + rectangle.height / 2, 0.0f);
            var scale = new Vector3(rectangle.width, rectangle.height, 0.0f);

            Rectangle(pos, color, scale);
        }

        /// <summary>
        /// Draws a rectangle of the specified color and size at the specified position
        /// </summary>
        public static void Rectangle(Vector3 position, Color color, Vector3 size)
        {
            var halfSize = size / 2f;

            var points = new[]
            {
                position + new Vector3(halfSize.x, halfSize.y, halfSize.z),
                position + new Vector3(-halfSize.x, halfSize.y, halfSize.z),
                position + new Vector3(-halfSize.x, -halfSize.y, halfSize.z),
                position + new Vector3(halfSize.x, -halfSize.y, halfSize.z),
            };

            Debug.DrawLine(points[0], points[1], color);
            Debug.DrawLine(points[1], points[2], color);
            Debug.DrawLine(points[2], points[3], color);
            Debug.DrawLine(points[3], points[0], color);
        }

        /// <summary>
        /// Draws a point of the specified color and size at the specified position
        /// </summary>
        public static void DrawPoint(Vector3 position, Color color, float size)
        {
            var points = new[]
            {
                position + (Vector3.up * size),
                position - (Vector3.up * size),
                position + (Vector3.right * size),
                position - (Vector3.right * size),
                position + (Vector3.forward * size),
                position - (Vector3.forward * size)
            };

            Debug.DrawLine(points[0], points[1], color);
            Debug.DrawLine(points[2], points[3], color);
            Debug.DrawLine(points[4], points[5], color);
            Debug.DrawLine(points[0], points[2], color);
            Debug.DrawLine(points[0], points[3], color);
            Debug.DrawLine(points[0], points[4], color);
            Debug.DrawLine(points[0], points[5], color);
            Debug.DrawLine(points[1], points[2], color);
            Debug.DrawLine(points[1], points[3], color);
            Debug.DrawLine(points[1], points[4], color);
            Debug.DrawLine(points[1], points[5], color);
            Debug.DrawLine(points[4], points[2], color);
            Debug.DrawLine(points[4], points[3], color);
            Debug.DrawLine(points[5], points[2], color);
            Debug.DrawLine(points[5], points[3], color);
        }
    }
}