using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Alignment")]
public class AlignmentBehavior : FilteredFlockBehavior
{
    public override Vector3 CalculateMove(Boid boid, List<Transform> neighbors, Flock flock)
    {
        if (neighbors.Count <= 0)
        {
            return boid.transform.forward;
        }
        
        Vector3 alignment = Vector3.zero;
        List<Transform> filteredNeighbors = (filter.Equals(null)) ? neighbors : filter.Filter(boid, neighbors);
        foreach (Transform item in filteredNeighbors)
        {
            alignment += item.transform.forward;
        }
        alignment /= neighbors.Count;
        return alignment;
    }
}
