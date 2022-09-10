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
        private Transform _barrel;
        public Transform Barrel => _barrel;

        private Rigidbody _rigidbody;

        private PlayerShipController _playerShipController;
        
        private BulletPool _bulletPool;
        public BulletPool BulletPool => _bulletPool;

        public Health Health { get; set; }
        public void Death()
        {
            print("you are die");
        }


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            
            var moveTransform = new AccelerationMove(_rigidbody, _preset.Speed,
                _preset.Speed * 2);
            
            var rotation = new RotationShip(transform);
            
            var ship = new Ship(moveTransform, rotation);
            
            _playerShipController = gameObject.AddComponent<PlayerShipController>();
            
            Health = new Health(_preset.Health, _preset.Health);
            _playerShipController.CreateShip(Camera.main, ship, this);

            _bulletPool = new BulletPool(gameObject);
        }

        private void Update()
        {

        }
    }
}