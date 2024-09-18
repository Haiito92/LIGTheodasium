using _Project.Runtime.Interfaces;
using _Project.Runtime.Scripts.Controllers;
using UnityEngine;
using UnityEngine.Events;

namespace _Project.Runtime.Scripts.Items
{
    public abstract class ItemPickUp : MonoBehaviour, IInteractable
    {
        public event UnityAction OnItemPickUp;

        [SerializeField] protected UnityEvent OnItemPickUpEvent;

        private void Awake()
        {
            OnItemPickUpEvent.AddListener(() => OnItemPickUp?.Invoke());
        }

        public void Interact(PlayerController player)
        {
            PickUp(player);
        }

        protected virtual void PickUp(PlayerController player)
        {
            OnItemPickUpEvent?.Invoke();
            Destroy(gameObject);
        }
    }
}
