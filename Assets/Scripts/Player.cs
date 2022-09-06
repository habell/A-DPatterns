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
        private Rigidbody _bullet;

        [SerializeField]
        private Transform _barrel;

        [SerializeField]
        private float _force;

        private Rigidbody _rigidbody;
        private Camera _camera;
        private Ship _ship;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(_rigidbody, _speed,
                _acceleration);
            var rotation = new RotationShip(transform);
            _ship = new Ship(moveTransform, rotation);
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