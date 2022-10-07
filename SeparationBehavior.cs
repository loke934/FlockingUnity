using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Separation")]
public class SeparationBehavior : FilteredFlockBehavior
{
    public override Vector3 CalculateMove(Boid boid, List<Transform> neighbors, Flock flock)
    {
        if (neighbors.Count <= 0)
        {
            return Vector3.zero;
        }
        
        Vector3 separation = Vector3.zero;
        int numberToAvoid = 0;
        List<Transform> filteredNeighbors = (filter.Equals(null)) ? neighbors : filter.Filter(boid, neighbors);
        foreach (Transform item in filteredNeighbors)
        {
            if (Vector3.SqrMagnitude(item.position-boid.transform.position) < flock.SquareAvoidanceRadius())
            {
                numberToAvoid++;
                separation += (boid.transform.position - item.position);
            }
        }

        if (numberToAvoid > 0)
        {
            separation /= numberToAvoid;
        }
        return separation;
    }
}
