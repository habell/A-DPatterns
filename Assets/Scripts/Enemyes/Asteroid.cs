using System;
using Enums;
using JetBrains.Annotations;
using ScriptableObjects;
using Unity.Mathematics;
using UnityEngine;

namespace Asteroids
{
    public sealed class Asteroid : Enemy, IHealth
    {
        private Rigidbody _rigidbody;
        
        public Health Health { get; set; }

        public void Death()
        {
            ReturnToPool();
        }

        private void Awake()
        {
            _rigidbody = gameObject.AddComponent<Rigidbody>();
            _rigidbody.useGravity = false;
            _rigidbody.freezeRotation = true;
            RefreshParameters();
        }

        private void Update()
        {
            _rigidbody.AddForce(Vector3.up / (100 - Preset.EnemyStruct.Speed));
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Player ply))
            {
                ply.Health.ChangeCurrentHealth(5);
                Death();
            }
        }

        protected override void RefreshParameters()
        {
            var hp = Preset.EnemyStruct.Health;
            Health = new Health(hp, hp);
        }
    }
}