using UnityEngine;

namespace Galaga
{
    [RequireComponent(typeof(Collider2D))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private Health health;
        [SerializeField]
        private SpawnPoint spawnPoint;


        private void FixedUpdate()
        {
            spawnPoint.TryFire();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Projectile bullet = collision.gameObject.GetComponent<Projectile>();
            if (bullet.isPlayer)
            {
                health.Damage(1);
                Debug.Log($"Enemy Hit. HP remaining: {health.HP}/{health.maxHP}");
                if (!health.isAlive)
                {
                    Destroy(this.gameObject);
                    Debug.Log("Enemy Died");
                }
            }
        }
    }
}