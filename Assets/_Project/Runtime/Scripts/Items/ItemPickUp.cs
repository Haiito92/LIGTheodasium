using _Project.Runtime.Interfaces;
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

        public void Interact()
        {
            PickUp();
        }

        protected virtual void PickUp()
        {
            OnItemPickUpEvent?.Invoke();
        }
    }
}
