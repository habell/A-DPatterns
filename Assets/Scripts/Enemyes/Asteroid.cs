using System;
using Unity.Mathematics;
using UnityEngine;

namespace Asteroids
{
    public sealed class Asteroid : Enemy
    {
        private Rigidbody _rigidbody;
        private void Awake()
        {
            _rigidbody = gameObject.AddComponent<Rigidbody>();
            _rigidbody.useGravity = false;
            _rigidbody.freezeRotation = true;
        }

        private void Update()
        {
            _rigidbody.AddForce(Vector3.up / 100);
        }
        
        
    }
}