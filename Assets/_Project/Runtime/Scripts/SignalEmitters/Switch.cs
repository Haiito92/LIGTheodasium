using _Project.Runtime.Interfaces;
using _Project.Runtime.Scripts.Controllers;
using NaughtyAttributes;
using UnityEngine;

namespace _Project.Runtime.Scripts.SignalEmitters
{
    public class Switch : SignalEmitter, IInteractable
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _toLeftAnimName;
        [SerializeField] private string _toRightAnimName;
        
        public void Interact(PlayerController player)
        {
            _isOn = !_isOn;
            
            Debug.Log("State: " + _isOn);
            
            _animator.Play(_isOn ? _toRightAnimName : _toLeftAnimName);
            
            EmitSignal(_isOn);
        }
    }
}
