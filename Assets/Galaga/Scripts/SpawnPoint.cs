using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

namespace Galaga
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField, Min(0f)]
        private int cooldownTime = 1;

        private Countdown cooldown;
        [SerializeField]
        private Projectile projectile;

        public void Awake()
        {
            cooldown = gameObject.AddComponent<Countdown>();
            cooldown.duration = cooldownTime;
        }

        public void TryFire()
        {
            if (!cooldown.isCountingDown) 
            {
                //Debug.Log("Shot Fired");
                Rigidbody2D body = GetComponent<Rigidbody2D>();
                Instantiate(projectile, body.position, Quaternion.identity);
                cooldown.Begin();
            }
            else 
            { 
                //Debug.Log("Fire on cooldown"); 
            }
        }
    }
}
