using UnityEngine;

namespace com.liteninja.utils
{
    public static class RaycastHelper
    {
        /// <summary>
        /// Draws a debug ray in 2D and does the actual raycast
        /// </summary>
        public static RaycastHit2D RayCast(Vector2 origin, Vector2 direction, float distance, LayerMask mask, Color color,bool drawGizmo=false)
        {	
            if (drawGizmo) 
            {
                Debug.DrawRay (origin, direction * distance, color);
            }
            return Physics2D.Raycast(origin,direction,distance,mask);		
        }

        /// <summary>
        /// Draws a debug ray without allocating memory
        /// </summary>
        public static RaycastHit2D MonoRayCastNonAlloc(RaycastHit2D[] array, Vector2 origin, Vector2 direction, float distance, LayerMask mask, Color color,bool drawGizmo=false)
        {	
            if (drawGizmo) 
            {
                Debug.DrawRay (origin, direction * distance, color);
            }
            return Physics2D.RaycastNonAlloc(origin, direction, array, distance, mask) > 0 ? array[0] : new RaycastHit2D();
        }

        /// <summary>
        /// Draws a debug ray in 3D and does the actual raycast
        /// </summary>
        public static RaycastHit Raycast3D(Vector3 origin, Vector3 direction, float distance, LayerMask mask, Color color,bool drawGizmo=false)
        {
            if (drawGizmo) 
            {
                Debug.DrawRay (origin, direction * distance, color);
            }

            Physics.Raycast(origin,direction,out var hit,distance,mask);	
            return hit;
        }
    }
}