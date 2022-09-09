using System.Collections.Generic;
using Asteroids;
using Enums;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Enemyes", menuName = "EnemyParams")]
    [Tooltip("This is enemy parameters")]
    public class EnemyParams : ScriptableObject
    {
        [SerializeField]
        private List<EnemyStruct> _enemyType;

        public List<EnemyStruct> EnemyType => _enemyType;
        
    }
}