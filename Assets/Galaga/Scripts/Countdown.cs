using UnityEngine;

namespace Galaga
{
    public class Countdown : MonoBehaviour
    {
        public int duration = 60;
        public int timeRemaining;
        public bool isCountingDown = false;

        public Countdown(int duration)
        {
            this.duration = duration;
        }

        public void Begin()
        {
            if (!isCountingDown)
            {
                isCountingDown = true;
                timeRemaining = duration;
                Invoke("_tick", 0.1f);
            }
        }

        private void _tick()
        {
            timeRemaining--;
            if (timeRemaining > 0)
            {
                Invoke("_tick", 0.1f);
            }
            else
            {
                isCountingDown = false;
            }
        }
    }
}