using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Runtime.Interfaces;
using UnityEngine;

namespace _Project.Runtime.Scripts
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private List<SignalEmitter> SignalEmitters;

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
            Debug.Log("OpenDoor");
        }

        private void Close()
        {
            Debug.Log("CloseDoor");
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
