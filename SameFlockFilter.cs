using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Filter/Same Flock")]
public class SameFlockFilter : ContextFilter
{
    public override List<Transform> Filter(Boid boid, List<Transform> original)
    {
        List<Transform> filtered = new List<Transform>();
        foreach (Transform item in original)
        {
            if (item.TryGetComponent(out Boid itemBoid) && itemBoid.OwningFlock == boid.OwningFlock)
            {
                filtered.Add(item);
            }
        }
        return filtered;
    }
}
