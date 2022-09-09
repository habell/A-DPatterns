using DefaultNamespace;
using ScriptableObjects;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody))]
    internal sealed class Player : MonoBehaviour, IHealth
    {
        [SerializeField]
        private PlayerPreset _preset;
        
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

        public BulletPool BulletPool => _bulletPool;

        public Health Health;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            
            var moveTransform = new AccelerationMove(_rigidbody, _speed,
                _acceleration);
            var rotation = new RotationShip(transform);
            var ship = new Ship(moveTransform, rotation);
            _platerShipController = gameObject.AddComponent<PlaterShipController>();

            Health = new Health(_preset.Health, _preset.Health);
            _platerShipController.CreateShip(Camera.main, ship);
        }

        private void Update()
        {

        }
    }

    internal interface IHealth
    {
    }
}