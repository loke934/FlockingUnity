using System.Collections.Generic;
using UnityEngine;

namespace Flocking.Filter
{
    public abstract class ContextFilter : ScriptableObject
    {
        public abstract List<Transform> Filter(Boid boid, List<Transform> original);
    }
}
