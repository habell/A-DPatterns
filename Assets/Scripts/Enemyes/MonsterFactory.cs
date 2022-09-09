using Asteroids;
using UnityEngine;

namespace Enemyes
{
    public class MonsterFactory : IEnemyFactory
    {
        private const string RESOURCE_FOLDER = "Enemy/Monster";
        public Enemy Create(Health hp)
        {
            var enemy =
                Object.Instantiate(Resources.Load<Asteroid>(RESOURCE_FOLDER));
            enemy.DependencyInjectHealth(hp);
            return enemy;
        }
    }
}