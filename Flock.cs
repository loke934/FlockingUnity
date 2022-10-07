using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Flock : MonoBehaviour
{
    [SerializeField] 
    private Boid boidPrefab;
    
    [SerializeField] 
    private FlockBehavior behavior;
    
    [SerializeField, Range(10, 500)] 
    private int flockSize = 250;
    
    [SerializeField, Range(1f, 100f)] 
    private float driveFactor = 10f;

    [SerializeField, Range(1f, 100f)] 
    private float maxSpeed = 5f;

    [SerializeField, Range(0f, 10f)] 
    private float neighbourRadius = 1.5f;
    
    [SerializeField, Range(0f, 1f)] 
    private float avoidanceRadiusMultiplier = 0.5f;
    
    private const float boidDensity = 0.08f;
    private List<Boid> boids;
    private float squareMaxSpeed;
    private float squareNeighbourRadius;
    private float squareAvoidanceRadius;

    public float SquareAvoidanceRadius() { return squareAvoidanceRadius;}
    
    // Start is called before the first frame update
    void Start()
    {
        boids = new List<Boid>();
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighbourRadius = neighbourRadius * neighbourRadius;
        squareAvoidanceRadius = squareNeighbourRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for (int i = 0; i < flockSize; i++)
        {
            Boid newBoid = Instantiate(boidPrefab, 
                Random.insideUnitSphere * flockSize * boidDensity,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)), 
                transform);

            newBoid.name = "Boid " + i;
            newBoid.SetOwningFlock(this);
            boids.Add(newBoid);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Boid boid in boids)
        {
            List<Transform> context = GetNearbyObjects(boid);
           // boid.GetComponent<Renderer>().material.color= Color.Lerp(Color.white, Color.red, context.Count / 6f);
            Vector3 move = behavior.CalculateMove(boid, context, this);
            move *= driveFactor;
            
            //if exceed max speed
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            boid.Move(move);
        }
    }

    List<Transform> GetNearbyObjects(Boid boid)
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
