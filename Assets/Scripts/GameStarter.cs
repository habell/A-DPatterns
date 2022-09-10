using Asteroids.Object_Pool;
using UnityEngine;
namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        private void Start()
        {
            EnemyPool enemyPool = new EnemyPool(5); 
            var enemy = enemyPool.GetEnemy("Asteroid");
            
            EnemyPool enemyPool1 = new EnemyPool(5); 
            var enemy1 = enemyPool1.GetEnemy("Monster");
            //enemy.transform.position = Vector3.one;
            //enemy.gameObject.SetActive(true);
            enemy.ActiveEnemy(Vector3.one, Quaternion.identity);
            enemy1.ActiveEnemy(Vector3.one, Quaternion.identity);
        }
    }
}