using UnityEngine;
namespace Asteroids
{
    public abstract class Enemy : MonoBehaviour
    {
        public static IEnemyFactory Factory;
        public Health Health { get; protected set; }
        public static Asteroid CreateAsteroidEnemy(Health hp)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));
            enemy.Health = hp;
            return enemy;
        }
        public void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }
    }
}