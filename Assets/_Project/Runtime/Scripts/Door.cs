using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project.Runtime.Scripts
{
    public class Door : MonoBehaviour
    {
        public List<Switch> Switches;

        private void OnEnable()
        {
            foreach (Switch aSwitch in Switches)
            {
                aSwitch.OnStateChanged += ReceiveSignal;
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
            foreach (Switch aSwitch in Switches)
            {
                aSwitch.OnStateChanged -= ReceiveSignal;
            }
        }

        private void OnDrawGizmosSelected()
        {
            if(Switches.Count <= 0 || Switches == null) return;

            Gizmos.color = Color.green;
            
            foreach (Switch aSwitch in Switches.Where(aSwitch => aSwitch != null))
            {
                Gizmos.DrawLine(transform.position, aSwitch.transform.position);
            }
        }
    }
}
