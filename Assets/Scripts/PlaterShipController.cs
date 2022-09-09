using System;
using UnityEngine;
namespace Asteroids
{
    public class PlaterShipController : MonoBehaviour 
    {
        private Camera _camera;
        private Ship _ship;
        private Player _ply;

        public void CreateShip(Camera camera, Ship ship)
        {
            _camera = camera;
            _ship = ship;
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
                
                //var temAmmunition = Instantiate(_bullet, _barrel.position,
                //    _barrel.rotation);
                //temAmmunition.AddForce(_barrel.up * _force);
            }
        }
    }
}