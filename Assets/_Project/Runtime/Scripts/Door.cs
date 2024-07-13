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
        [SerializeField] private SpriteRenderer _sp;
        
        private void OnEnable()
        {
            _sp.color = Color.red; //For testing purposes only, should be removed after
            
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
            _sp.color = Color.green;//For testing purposes only, should be removed after
        }

        private void Close()
        {
            Debug.Log("CloseDoor");
            _sp.color = Color.red;//For testing purposes only, should be removed after
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
