using UnityEngine;
using UnityEngine.Events;

namespace _Project.Runtime.Scripts
{
    public abstract class SignalEmitter : MonoBehaviour
    {
        protected bool _isOn;
        
        public event UnityAction<bool> OnStateChanged;
        
        protected virtual void EmitSignal()
        {
            OnStateChanged?.Invoke(_isOn);
        }
    }
}
