using System.Collections.Generic;
using Flocking.Behavior;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Flocking
{
    public class Flock : MonoBehaviour
    {
        [Header("Flock behavior")]
        [SerializeField] 
        private FlockBehavior behavior;
        [SerializeField, Range(1, 500)] 
        private int flockSize = 250;
        [SerializeField, Range(1f, 100f)] 
        private float driveFactor = 10f;
        [SerializeField, Range(1f, 100f)] 
        private float maxSpeed = 5f;
        [SerializeField, Range(0f, 10f)] 
        private float neighbourRadius = 1.5f;
        [SerializeField, Range(0f, 1f)] 
        private float avoidanceRadiusMultiplier = 0.5f;
    
        [SerializeField] 
        private Boid boidPrefab;
    
        private const float BoidDensity = 0.08f;
        private List<Boid> _boids;
        private float _squareMaxSpeed;
        private float _squareNeighbourRadius;
        private float _squareAvoidanceRadius;

        public float SquareAvoidanceRadius() => _squareAvoidanceRadius;

        private void Awake()
        {
            _boids = new List<Boid>();
            _squareMaxSpeed = maxSpeed * maxSpeed;
            _squareNeighbourRadius = neighbourRadius * neighbourRadius;
            _squareAvoidanceRadius = _squareNeighbourRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;
        }

        void Start()
        {
            SpawnBoids();
        }

        void Update()
        {
            foreach (Boid boid in _boids)
            {
                List<Transform> context = GetNearbyObjects(boid);
                Vector3 move = behavior.CalculateMove(boid, context, this);
                move *= driveFactor;
            
                //if max speed exceeded
                if (move.sqrMagnitude > _squareMaxSpeed)
                {
                    move = move.normalized * maxSpeed;
                }
                boid.Move(move);
            }
        }

        private void SpawnBoids()
        {
            for (int i = 0; i < flockSize; i++)
            {
                Boid newBoid = Instantiate(boidPrefab, 
                    Random.insideUnitSphere * flockSize * BoidDensity,
                    Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)), 
                    transform);

                newBoid.name = "Boid " + i;
                newBoid.OwningFlock = this;
                _boids.Add(newBoid);
            }
        }

        private List<Transform> GetNearbyObjects(Boid boid)
        {
            List<Transform> context = new List<Transform>();
            Collider[] contextColliders = Physics.OverlapSphere(boid.transform.position, neighbourRadius);
            foreach (Collider col in contextColliders)
            {
                if (col != boid.BoidCollider)
                {
                    context.Add(col.transform);
                }
            }
            return context;
        }
    }
}
