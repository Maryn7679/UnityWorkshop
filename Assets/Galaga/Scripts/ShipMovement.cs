using UnityEngine;

namespace Galaga
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ShipMovement : MonoBehaviour
    {
        [SerializeField, Min(0f)]
        private float speed = 5f;

        private float leftBorderX = -8f;
        private float rightBorderX = 8f;

        [SerializeField]
        private Health health;
        [SerializeField]
        private SpawnPoint spawnPoint;
        private Rigidbody2D body;

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                spawnPoint.TryFire();
            }
        }

        private void FixedUpdate()
        {
            float input = GetMovementDirection(KeyCode.A, KeyCode.D);
            if (body.position.x <= leftBorderX && input <= 0)
            {
                body.position = new Vector3(leftBorderX, 0.0f, 0.0f);
            }
            else if (body.position.x >= rightBorderX && input >= 0)
            {
                body.position = new Vector3(rightBorderX, 0.0f, 0.0f);
            }
            else
            {
                //Debug.Log($" {body.position.x}");
                Vector2 velocity = body.linearVelocity;
                velocity.x = input * speed;
                body.linearVelocity = velocity;
            }
        }

        private static float GetMovementDirection(KeyCode negative, KeyCode positive)
        {
            float value = 0f;
            if (Input.GetKey(negative))
            {
                value -= 1f;
            }

            if (Input.GetKey(positive))
            {
                value += 1f;
            }

            return value;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Projectile bullet = collision.gameObject.GetComponent<Projectile>();
            if (!bullet.isPlayer)
            {
                health.Damage(1);
                Debug.Log($"Player Hit. HP remaining: {health.HP}/{health.maxHP}");
                if (!health.isAlive)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
