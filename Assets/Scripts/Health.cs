using UnityEngine;

namespace Asteroids
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private float _hp;

        public float HP
        {
            get { return _hp; }
            set
            {
                _hp -= value;
                if (_hp <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            HP--;
        }
    }
}