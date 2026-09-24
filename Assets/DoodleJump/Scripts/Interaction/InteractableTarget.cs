using System;
using UnityEngine;

namespace UnityLab.Components
{
    [AddComponentMenu("Unity Lab/Interaction/Interactable Target")]
    public class InteractableTarget : MonoBehaviour, IInteractable, IPointsSource
    {
        public enum InteractionResult
        {
            Destroy,
            Hide,
            Disable
        }

        [Header("Interaction")]
        [Tooltip("Points awarded when this object is clicked or otherwise interacted with. Use 0 for no score.")]
        [SerializeField]
        private int points = 1;

        [Tooltip("Destroy removes the object. Hide turns it off so it can be used again later.")]
        [SerializeField]
        private InteractionResult interactionResult = InteractionResult.Destroy;
        private bool interacted = false;

        public event Action<int> PointsAwarded;

        public void Interact()
        {
            if (points != 0)
            {
                PointsAwarded?.Invoke(points);
            }

            if (interactionResult == InteractionResult.Hide)
            {
                gameObject.SetActive(false);
            }
            if (interactionResult == InteractionResult.Disable)
            {
                var renderer = gameObject.GetComponent<Renderer>();
                Color disabledColor = new Color(1f, 1f, 1f, 0.3f);
                renderer.material.SetColor("_Color", disabledColor);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!interacted && interactionResult == InteractionResult.Disable)
            {
                Interact();
                interacted = true;
            }
        }
    }
}
