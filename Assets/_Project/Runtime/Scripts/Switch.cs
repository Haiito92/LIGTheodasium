using _Project.Runtime.Interfaces;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace _Project.Runtime.Scripts
{
    public class Switch : MonoBehaviour, IInteractable
    {
        private bool _isOn;

        public event UnityAction<bool> OnStateChanged;
        
        [Button]
        public void Interact()
        {
            _isOn = !_isOn;
            
            Debug.Log("State: " + _isOn);
            
            OnStateChanged?.Invoke(_isOn);
        }
    }
}
