using System.Collections.Generic;
using Asteroids;
using Asteroids.Object_Pool;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class BulletPool
    {
        private const int DEFAULT_BULLETS = 15;
        private List<Bullet> _bullets = new();
        private Transform _poolParent;
        private BulletFactory _bulletFactory;
        
        public BulletPool(GameObject parent)
        {
            _poolParent = new GameObject(NameManager.POOL_PLAYER_AMMO).transform;
            _poolParent.SetParent(parent.transform);

            _bulletFactory = new BulletFactory();
            for (int i = 0; i < DEFAULT_BULLETS; i++)
            {
                CreateNewBullet();
            }
        }
        public List<Bullet> GetPool()
        {
            return _bullets;
        }

        public Bullet GetBullet()
        {
            foreach (var bullet in _bullets)
            {
                if (!bullet.gameObject.activeSelf)
                {
                    return bullet;
                }
            }
            
            return CreateNewBullet();
        }

        private Bullet CreateNewBullet()
        {
            var bullet = _bulletFactory.Create();
            bullet.gameObject.SetActive(false);
            bullet.gameObject.transform.SetParent(_poolParent);
            _bullets.Add(bullet);
            return bullet;
        }
    }
}