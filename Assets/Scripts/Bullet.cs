using UnityEngine;

namespace Asteroids
{
    public class Bullet : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Enemy enemy))
            {
                enemy.gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}