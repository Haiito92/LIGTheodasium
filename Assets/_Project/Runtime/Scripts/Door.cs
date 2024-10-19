using System.Collections.Generic;
using System.Linq;
using _Project.Runtime.Scripts.SignalEmitters;
using UnityEngine;

namespace _Project.Runtime.Scripts
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private List<SignalEmitter> SignalEmitters;

        //Field for testing, meant to be removed after;
        [SerializeField] private Animator _animator;
        [SerializeField] private string _closeAnimName;
        [SerializeField] private string _openAnimName;
        
        private void OnEnable()
        {
            foreach (SignalEmitter emitter in SignalEmitters)
            {
                emitter.OnStateChanged += ReceiveSignal;
            }
        }

        private void ReceiveSignal(bool signalOn)
        {
            if (signalOn)
            {
                Open();
            }
            else
            {
                Close();
            }
        }
        
        private void Open()
        {
            _animator.Play(_openAnimName);
        }

        private void Close()
        {
            _animator.Play(_closeAnimName);
        }

        private void OnDisable()
        {
            foreach (SignalEmitter emitter in SignalEmitters)
            {
                emitter.OnStateChanged += ReceiveSignal;
            }
        }

        private void OnDrawGizmosSelected()
        {
            if(SignalEmitters.Count <= 0 || SignalEmitters == null) return;

            Gizmos.color = Color.green;
            
            foreach (SignalEmitter emitter in SignalEmitters.Where(emitter => emitter != null))
            {
                Gizmos.DrawLine(transform.position, emitter.transform.position);
            }
        }
    }
}
