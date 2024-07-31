using _Project.Runtime.Interfaces;
using _Project.Runtime.Scripts.Controllers;
using NaughtyAttributes;
using UnityEngine;

namespace _Project.Runtime.Scripts.SignalEmitters
{
    public class Switch : SignalEmitter, IInteractable
    {
        public void Interact(PlayerController player)
        {
            _isOn = !_isOn;
            
            Debug.Log("State: " + _isOn);
            
            EmitSignal(_isOn);
        }
    }
}
