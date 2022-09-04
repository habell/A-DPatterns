using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Health))]
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        [SerializeField]
        private float _acceleration;

        [SerializeField]
        private Health _health;

        [SerializeField]
        private Rigidbody _bullet;

        [SerializeField]
        private Transform _barrel;

        [SerializeField]
        private float _force;

        private Camera _camera;
        private Ship _ship;

        private void Start()
        {
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(transform, _speed,
                _acceleration);
            var rotation = new RotationShip(transform);
            _ship = new Ship(moveTransform, rotation);
            _health = gameObject.GetComponent<Health>();
        }

        private void Update()
        {
            var direction = Input.mousePosition -
                            _camera.WorldToScreenPoint(transform.position);
            _ship.Rotation(direction);
            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),
                Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                var temAmmunition = Instantiate(_bullet, _barrel.position,
                    _barrel.rotation);
                temAmmunition.AddForce(_barrel.up * _force);
            }
        }
    }
}