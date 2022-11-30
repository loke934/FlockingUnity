using UnityEngine;

namespace Flocking
{
    [RequireComponent(typeof(Collider))]
    public class Boid : MonoBehaviour
    {
        private Transform _transform;
        private Flock _owningFlock;
        private Collider _boidCollider;

        public Flock OwningFlock
        {
            get => _owningFlock;
            set => _owningFlock = value;
        }
        public Collider BoidCollider => _boidCollider;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _boidCollider = GetComponent<Collider>();
        }
    
        public void Move(Vector3 offsetPosition)
        {
            _transform.forward = offsetPosition;
            _transform.position += offsetPosition * Time.deltaTime;
        }
  
    }
}
