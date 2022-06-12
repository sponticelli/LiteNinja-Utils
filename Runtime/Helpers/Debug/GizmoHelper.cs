using UnityEngine;

namespace com.liteninja.utils
{
    public static class GizmoHelper
    {
        /// <summary>
        /// Draws a gizmo arrow going from the origin position and along the direction Vector3
        /// </summary>
        public static void Arrow(Vector3 origin, Vector3 direction, Color color)
        {
            const float arrowHeadLength = 3.00f;
            const float arrowHeadAngle = 25.0f;

            Gizmos.color = color;
            Gizmos.DrawRay(origin, direction);

            ArrowEnd(origin, direction, color, arrowHeadLength, arrowHeadAngle);
        }

        /// <summary>
        /// Draws a gizmo sphere of the specified size and color at a position
        /// </summary>
        public static void Point(Vector3 position, float size, Color color)
        {
            Gizmos.color = color;
            Gizmos.DrawWireSphere(position, size);
        }

        public static void Cube(Transform transform, Vector3 offset, Vector3 cubeSize, bool wireOnly)
        {
            var rotationMatrix = transform.localToWorldMatrix;
            Gizmos.matrix = rotationMatrix;
            if (wireOnly)
            {
                Gizmos.DrawWireCube(offset, cubeSize);
            }
            else
            {
                Gizmos.DrawCube(offset, cubeSize);
            }
        }

        /// <summary>
        /// Draws a gizmo rectangle
        /// </summary>
        public static void Rectangle(Vector2 center, Vector2 size, Color color)
        {
            Gizmos.color = color;

            var v3TopLeft = new Vector3(center.x - size.x / 2, center.y + size.y / 2, 0);
            var v3TopRight = new Vector3(center.x + size.x / 2, center.y + size.y / 2, 0);
            ;
            var v3BottomRight = new Vector3(center.x + size.x / 2, center.y - size.y / 2, 0);
            ;
            var v3BottomLeft = new Vector3(center.x - size.x / 2, center.y - size.y / 2, 0);
            ;

            Gizmos.DrawLine(v3TopLeft, v3TopRight);
            Gizmos.DrawLine(v3TopRight, v3BottomRight);
            Gizmos.DrawLine(v3BottomRight, v3BottomLeft);
            Gizmos.DrawLine(v3BottomLeft, v3TopLeft);
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

            Gizmos.color = color;
            Gizmos.DrawRay(arrowEndPosition + direction, right * arrowHeadLength);
            Gizmos.DrawRay(arrowEndPosition + direction, left * arrowHeadLength);
            Gizmos.DrawRay(arrowEndPosition + direction, up * arrowHeadLength);
            Gizmos.DrawRay(arrowEndPosition + direction, down * arrowHeadLength);
        }
    }
}