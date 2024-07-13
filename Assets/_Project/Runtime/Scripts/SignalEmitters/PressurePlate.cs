using System;
using NaughtyAttributes;
using UnityEngine;

namespace _Project.Runtime.Scripts.SignalEmitters
{
    public class PressurePlate : SignalEmitter
    {
        private int _objAmountOnPlate = 0;

        #region Properties

        private int ObjAmountOnPlate
        {
            get => _objAmountOnPlate;
            set
            {
                int oldAmount = _objAmountOnPlate;
                
                _objAmountOnPlate = Mathf.Clamp(value, 0, Int32.MaxValue);

                switch (oldAmount)
                {
                    case 0 when _objAmountOnPlate > 0:
                        PressPlate();
                        break;
                    case > 0 when _objAmountOnPlate == 0:
                        ReleasePlate();
                        break;
                }
            }
        }

        #endregion

        private void PressPlate()
        {
            _isOn = true;
            EmitSignal(_isOn);
        }

        private void ReleasePlate()
        {
            _isOn = false;
            EmitSignal(_isOn);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            ++ObjAmountOnPlate;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            --ObjAmountOnPlate;
        }
        
        //For Test, To be removed
        [Button]
        public void IncrementObjAmount() => ++ObjAmountOnPlate;
        [Button]
        public void DecrementObjAmount() => --ObjAmountOnPlate;
    }
}
