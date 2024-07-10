using _Project.Runtime.Interfaces;
using UnityEngine;

namespace _Project.Runtime.Scripts
{
    public class Button : SignalEmitter, IInteractable
    {
        [SerializeField] private float _releaseTime = 1f;

        public void Interact()
        {
            EmitSignal();
        }

    }
}
