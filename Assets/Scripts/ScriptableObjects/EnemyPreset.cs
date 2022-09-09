using Asteroids;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "EnemyPreset")]
    public class EnemyPreset : ScriptableObject, IPreset
    {
        [SerializeField]
        private EnemyStruct _enemyStruct;
        public EnemyStruct EnemyStruct => _enemyStruct;
    }
    
}