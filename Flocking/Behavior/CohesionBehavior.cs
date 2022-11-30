using System.Collections.Generic;
using UnityEngine;

namespace Flocking.Behavior
{
    [CreateAssetMenu(menuName = "Flock/Behaviour/Cohesion")]
    public class CohesionBehavior : FilteredFlockBehavior
    {
        public override Vector3 CalculateMove(Boid boid, List<Transform> neighbors, Flock flock)
        {
            if (neighbors.Count <= 0)
            {
                return Vector3.zero;
            }
        
            Vector3 cohesion = Vector3.zero;
            List<Transform> filteredNeighbors = (filter.Equals(null)) ? neighbors : filter.Filter(boid, neighbors);
            foreach (Transform item in filteredNeighbors)
            {
                cohesion += item.position;
            }
            cohesion /= neighbors.Count;
            cohesion -= boid.transform.position;
            return cohesion;
        }
    }
}
