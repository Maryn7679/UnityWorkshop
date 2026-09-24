using System;
using System.Collections;
using UnityEngine;
using UnityLab.Components;

namespace UnityLab.Components
{
    [RequireComponent(typeof(Collider2D))]
    public class CollisionPoints : MonoBehaviour
    {
        [Tooltip("Points awarded when a valid object enters this zone.")]
        [SerializeField]
        private int points = 1;

        [Tooltip("Layers that can score here, usually the ball.")]
        [SerializeField]
        private LayerMask targetLayer = ~0;

        public event Action<int> Scored;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            TryScore(collision.gameObject);
        }

        private void TryScore(GameObject other)
        {
            if (other == null || ((1 << other.layer) & targetLayer) == 0)
            {
                return;
            }

            if (points != 0)
            {
                Scored?.Invoke(points);
            }
        }
    }
}