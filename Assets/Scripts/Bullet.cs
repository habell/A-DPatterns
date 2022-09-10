using System;
using System.Collections;
using UnityEngine;

namespace Asteroids
{
    internal class Bullet : MonoBehaviour
    {
        [SerializeField]
        private float _bulletForce;

        [SerializeField]
        private float _bulletLifeTime;

        private Rigidbody _rigidbody;

        private Transform _oldParent;

        public float Force => _bulletForce;


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Shot(Player ply)
        {
            transform.position = ply.Barrel.position;
            var parent = ply.BulletPool.PoolParent;
            _oldParent = parent;
            transform.SetParent(null);
            gameObject.SetActive(true);
            _rigidbody.AddForce(ply.Barrel.up * Force);
            StartCoroutine(ShotTimer());
        }

        private void OnCollisionEnter(Collision collision)
        {
            var collided = collision.gameObject;

            print(collided.transform);
            print(_oldParent.transform);
            
            if (collided.transform == _oldParent) return;

            if (collided.TryGetComponent(out IHealth enemy))
            {
                print("STTTT");
                enemy.Death();
            }
            ReturnObjToParent();
        }

        private IEnumerator ShotTimer()
        {
            yield return new WaitForSeconds(_bulletLifeTime);
            if (gameObject.activeSelf)
            {
                ReturnObjToParent();
            }
        }

        private void ReturnObjToParent()
        {
            transform.SetParent(_oldParent);
            gameObject.SetActive(false);
            //transform.position = Vector3.back;
        }
    }
}