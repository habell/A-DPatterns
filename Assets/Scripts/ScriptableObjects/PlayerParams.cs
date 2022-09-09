using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Player", menuName = "PlayerParameters")]
    public class PlayerParams : ScriptableObject
    {
        [SerializeField]
        private float _health;

        [SerializeField]
        private float _speed;

        [SerializeField]
        private float _damage;

        public float Health => _health;
        public float Speed => _speed;
        public float Damage => _damage;
    }
}