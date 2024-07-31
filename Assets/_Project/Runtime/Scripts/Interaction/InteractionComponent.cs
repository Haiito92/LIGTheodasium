using System.Collections.Generic;
using _Project.Runtime.Interfaces;
using _Project.Runtime.Scripts.Controllers;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace _Project.Runtime.Scripts.Interaction
{
    public class InteractionComponent : MonoBehaviour
    {
        //Fields
        [SerializeField] private float _interactionRadius = 1f;
        private IInteractable _closestInteractable = null;
        
        //Actions
        public event UnityAction OnInteractionDone; 
        
        //UnityEvent (for GD)
        [SerializeField] private UnityEvent OnInteractionDoneEvent;

        private void Awake()
        {
            OnInteractionDoneEvent.AddListener(() => OnInteractionDone?.Invoke());
        }

        private void Update()
        {
            if (FindClosestInteractable(GetInRangeInteractables(transform.position, _interactionRadius),
                    out IInteractable closestInteractable))
            {
                _closestInteractable = closestInteractable;
            }
        }

        private List<IInteractable> GetInRangeInteractables(Vector2 interactionPoint, float interactionRadius)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(interactionPoint, interactionRadius);

            List<IInteractable> inRangeInteractables = new List<IInteractable>();

            foreach (Collider2D collider in colliders)
            {
                if (collider.TryGetComponent(out IInteractable interactable))
                {
                    inRangeInteractables.Add(interactable);
                }
            }

            return inRangeInteractables;
        }
        
        private bool FindClosestInteractable(List<IInteractable> inRangeInteractables, out IInteractable closestInteractable)
        {
            closestInteractable = null;

            if (inRangeInteractables == null || inRangeInteractables.Count == 0) return false;

            float closestDistance = 0f;

            foreach (IInteractable interactable in inRangeInteractables)
            {
                if (interactable is not MonoBehaviour mbInteractable) continue;
                
                float distance = Vector2.Distance(transform.position, mbInteractable.transform.position);
                
                if (distance > closestDistance)
                {
                    closestDistance = distance;
                    closestInteractable = (IInteractable)mbInteractable;
                }
            }

            return closestInteractable != null;
        }

        public void DoInteraction(PlayerController player)
        {
            if(_closestInteractable == null) return;
            
            Debug.Log("Do interaction");
            
            _closestInteractable.Interact(player);
            
            OnInteractionDoneEvent?.Invoke();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            
            Gizmos.DrawWireSphere(transform.position, _interactionRadius);
        }
    }
}
