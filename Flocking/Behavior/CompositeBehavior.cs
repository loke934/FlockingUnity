using System.Collections.Generic;
using UnityEngine;

namespace Flocking.Behavior
{
    [CreateAssetMenu(menuName = "Flock/Behaviour/Composite")]
    public class CompositeBehavior : FlockBehavior
    {
        public FlockBehavior[] behaviors;

        public float[] weights;
    
        public override Vector3 CalculateMove(Boid boid, List<Transform> neighbors, Flock flock)
        {
            if (weights.Length != behaviors.Length)
            {
                Debug.Log("Mismatch in weights and behaviors in " + name, this);
                return Vector3.zero;
            }
        
            Vector3 move = Vector3.zero;
            for (int i = 0; i < behaviors.Length; i++)
            {
                Vector3 partialMove = behaviors[i].CalculateMove(boid, neighbors, flock) * weights[i];

                if (partialMove != Vector3.zero)
                {
                    if (partialMove.sqrMagnitude > weights[i] * weights[i])
                    {
                        partialMove.Normalize();
                        partialMove *= weights[i];
                    }
                    move += partialMove;
                }
            }
            return move;
        }
    }
}
