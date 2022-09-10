namespace Asteroids
{
    public interface IHealth
    {
        public Health Health { get; set; }

        public void Death();
    }
}