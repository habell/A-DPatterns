using System;
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
        private EnemyPreset _preset; 
        
        private Transform _rootPool;
        
        public EnemyPreset Preset => _preset;

        protected abstract void RefreshParameters();
        
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
        
        public void ActiveEnemy(Vector3 position, Quaternion rotation)
        {
            transform.localPosition = position;
            transform.localRotation = rotation;
            gameObject.SetActive(true);
            transform.SetParent(null);
            RefreshParameters();
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
        //public void DependencyInjectHealth(Health hp)
        //{
        //    Health = hp;
        //}

    }
}
