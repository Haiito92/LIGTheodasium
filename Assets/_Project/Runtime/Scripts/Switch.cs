using _Project.Runtime.Interfaces;
using NaughtyAttributes;
using UnityEngine;

namespace _Project.Runtime.Scripts
{
    public class Switch : SignalEmitter, IInteractable
    {
        [Button]
        public void Interact()
        {
            _isOn = !_isOn;
            
            Debug.Log("State: " + _isOn);
            
            EmitSignal();
        }
    }
}
