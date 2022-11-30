using System.Collections.Generic;
using UnityEngine;

namespace Flocking.Behavior
{
   [CreateAssetMenu(menuName = "Flock/Behaviour/Stay Within Radius")]
   public class StayWithinRadiusBehavior : FlockBehavior
   {
      [SerializeField]
      private Vector3 center;

      [SerializeField] 
      private float radius = 15f;

      [SerializeField, Range(0f,1f)] 
      private float radiusThreshold = 0.9f;
      public override Vector3 CalculateMove(Boid boid, List<Transform> neighbors, Flock flock)
      {
         Vector3 centerOffset = center - boid.transform.position;
         float t = centerOffset.magnitude / radius;
         if (t < radiusThreshold)
         {
            return Vector3.zero;
         }
         return centerOffset * (t * t);
      }
   }
}
