using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Boid : MonoBehaviour
{
    private Flock owningFlock;
    public Flock OwningFlock => owningFlock;

    private Collider boidCollider; 
    public Collider BoidCollider => boidCollider;
   
    
    void Start()
    {
        boidCollider = GetComponent<Collider>();
    }

    public void SetOwningFlock(Flock flock)
    {
        owningFlock = flock;
    }

    public void Move(Vector3 offsetPosition)
    {
        transform.forward = offsetPosition;
        transform.position += offsetPosition * Time.deltaTime;
    }
  
}
