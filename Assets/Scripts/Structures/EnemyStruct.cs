using System;
using Enums;

namespace ScriptableObjects
{
    [Serializable]
    public struct EnemyStruct
    {
        public EnemyType _type;
        public float Health;
        public float Damage;
        public float Speed;
    }
}