using DefaultNamespace;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody))]
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        [SerializeField]
        private float _acceleration;

        [SerializeField]
        private Transform _barrel;

        [SerializeField]
        private float _force;

        private Rigidbody _rigidbody;

        private PlaterShipController _platerShipController;
        
        private BulletPool _bulletPool;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();

            var moveTransform = new AccelerationMove(_rigidbody, _speed,
                _acceleration);
            var rotation = new RotationShip(transform);
            var ship = new Ship(moveTransform, rotation);
            _platerShipController = gameObject.AddComponent<PlaterShipController>();
            _platerShipController.CreateShip(Camera.main, ship);
        }

        private void Update()
        {

        }
    }
}