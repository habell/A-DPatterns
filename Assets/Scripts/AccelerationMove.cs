using UnityEngine;
namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody))]
    internal sealed class AccelerationMove : MoveTransform
    {
        private readonly float _acceleration;
        public AccelerationMove(Rigidbody rigidbody, float speed, float acceleration)
            : base(rigidbody, speed)
        {
            _acceleration = acceleration;
        }
        public void AddAcceleration()
        {
            Speed += _acceleration;
        }
        public void RemoveAcceleration()
        {
            Speed -= _acceleration;
        }
    }
}