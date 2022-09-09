using UnityEngine;

namespace Asteroids
{
    public class BulletFactory
    {
        public Bullet Create()
        {
            var bullet = Object.Instantiate(Resources.Load<Bullet>("Prefabs/Bullet"));
            return bullet;
        }
    }
}