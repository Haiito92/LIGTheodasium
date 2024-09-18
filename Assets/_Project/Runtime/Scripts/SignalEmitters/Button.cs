using _Project.Runtime.Interfaces;
using _Project.Runtime.Scripts.Controllers;
using NaughtyAttributes;
using UnityEngine;

namespace _Project.Runtime.Scripts.SignalEmitters
{
    public class Button : SignalEmitter, IInteractable
    {
        [SerializeField] private float _timeToRelease = 1f;
        private float _releaseTimer;
        private float _elapsedTime;

        private void Update()
        {
            if (_isOn)
            {
                _releaseTimer += Time.deltaTime;

                if (_releaseTimer >= _timeToRelease)
                {
                    ReleaseButton();
                }
            }
        }

        public void Interact(PlayerController player)
        {
            PushButton();
        }

        private void PushButton()
        {
            _isOn = true;

            _releaseTimer = 0;
            
            EmitSignal(_isOn);
            
            Debug.Log("Push Button");
        }

        private void ReleaseButton()
        {
            _isOn = false;
            
            EmitSignal(_isOn);
            
            Debug.Log("Release Button");
        }
    }
}
