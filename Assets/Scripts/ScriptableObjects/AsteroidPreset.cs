using Asteroids;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Asteroid", menuName = "AsteroidPreset")]
    public class AsteroidPreset : ScriptableObject, IPreset
    {
        [SerializeField]
        private EnemyStruct _enemyStruct;
        public EnemyStruct EnemyStruct => _enemyStruct;
    }
    
}