using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Flock/Behaviour/Steered Cohesion")]
public class SteeredCohesionBehavior : FilteredFlockBehavior
{
    [SerializeField, Range(0f,10f)]
    private float boidSmoothTime = 0.5f;
    
    private Vector3 currentVelocity;
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
        cohesion = Vector3.SmoothDamp(boid.transform.forward, cohesion, ref currentVelocity, boidSmoothTime);
        return cohesion;
    }
}
