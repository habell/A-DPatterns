using UnityEngine;

namespace Asteroids
{
    public class Health
    {
        public float Max { get; }
        public float Current { get; private set; }

        public Health(float max, float current)
        {
            Max = max;
            Current = current;
        }

        public void ChangeCurrentHealth(float hp)
        {
            Current = hp;
            if (Current <= 0)
            {
                Debug.Log("This object is DEATH!");
            }
        }
    }
}