using System;
using Enums;
using ScriptableObjects;
using Unity.Mathematics;
using UnityEngine;

namespace Asteroids
{
    public sealed class Asteroid : Enemy, IEnemy
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

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Player ply))
            {
                ply.Health.ChangeCurrentHealth(5);
            }
        }
    }
}