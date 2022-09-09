using UnityEngine;

namespace Asteroids
{
    internal sealed class AsteroidFactory : IEnemyFactory
    {
        private const string RESOURCE_FOLDER = "Enemy/Asteroid";
        public Enemy Create(Health hp)
        {
            var enemy =
                Object.Instantiate(Resources.Load<Asteroid>(RESOURCE_FOLDER));
            enemy.DependencyInjectHealth(hp);
            return enemy;
        }
    }
}