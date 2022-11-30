using System.Collections.Generic;
using UnityEngine;

namespace Flocking.Behavior
{
    public abstract class FlockBehavior : ScriptableObject
    {
        public abstract Vector3 CalculateMove(Boid boid, List<Transform> neighbors, Flock flock);
    }
}
