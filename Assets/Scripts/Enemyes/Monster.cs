namespace Asteroids
{
    public class Monster : Enemy
    {
        protected override void RefreshParameters()
        {
            print("Spawned");
        }
    }
}