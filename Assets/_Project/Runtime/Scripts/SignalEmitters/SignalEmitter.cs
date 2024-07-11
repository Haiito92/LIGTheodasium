using UnityEngine;
using UnityEngine.Events;

namespace _Project.Runtime.Scripts.SignalEmitters
{
    public abstract class SignalEmitter : MonoBehaviour
    {
        protected bool _isOn;
        
        public event UnityAction<bool> OnStateChanged;
        
        protected virtual void EmitSignal(bool signalValue)
        {
            OnStateChanged?.Invoke(signalValue);
        }
    }
}
