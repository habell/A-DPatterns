using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{

    internal class MoveTransform : IMove
    {
        //private readonly Transform _transform;
        private Rigidbody _rigidbody;
        private Vector3 _move;
        public float Speed { get; protected set; }

        public MoveTransform(Rigidbody rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            Speed = speed;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            _rigidbody.AddForce(_move, ForceMode.Impulse);
        }
    }
}