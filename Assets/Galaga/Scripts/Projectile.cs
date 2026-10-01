using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Windows;

namespace Galaga
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField, Min(0f)]
        private float speed = 5f;
        [SerializeField]
        public bool isPlayer = true;
        private float topBorderY = 4f;
        private float bottomBorderY = -5f;

        private Rigidbody2D body;

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
        }

        public void FixedUpdate()
        {
            Vector2 velocity = body.linearVelocity;
            velocity.y = ((isPlayer) ? 1 : -1) * speed;
            body.linearVelocity = velocity;
            if (body.position.y > topBorderY || body.position.y < bottomBorderY)
            {
                //Debug.Log("Bullet Destroyed");
                Destroy(this.gameObject);
            }
        }
    }
}