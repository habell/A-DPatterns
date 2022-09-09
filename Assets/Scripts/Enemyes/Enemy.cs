using Asteroids.Object_Pool;
using Enums;
using ScriptableObjects;
using UnityEngine;
namespace Asteroids
{
    public abstract class Enemy : MonoBehaviour
    {
        public static IEnemyFactory Factory;
        
        [SerializeField]
        private EnemyType _enemyType;
        
        public EnemyType EnemyType => _enemyType;

        private Transform _rootPool;

        private Health _health;

        public Health Health
        {
            get
            {
                if (_health.Current <= 0.0f)
                {
                    ReturnToPool();
                }

                return _health;
            }
            protected set => _health = value;
        }

        public Transform RootPool
        {
            get
            {
                if (_rootPool == null)
                {
                    var find = GameObject.Find(NameManager.POOL_AMMUNITION);
                    _rootPool = find == null ? null : find.transform;
                }
                return _rootPool;
            }
        }
        public static Asteroid CreateAsteroidEnemy(Health hp)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));
            enemy.Health = hp;
            return enemy;
        }
        public void ActiveEnemy(Vector3 position, Quaternion rotation)
        {
            transform.localPosition = position;
            transform.localRotation = rotation;
            gameObject.SetActive(true);
            transform.SetParent(null);
        }
        protected void ReturnToPool()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            transform.SetParent(RootPool);
            if (!RootPool)
            {
                Destroy(gameObject);
            }
        }
        public void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }

    }
}
