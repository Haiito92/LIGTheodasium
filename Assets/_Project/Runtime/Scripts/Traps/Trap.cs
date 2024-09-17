using System.Collections.Generic;
using _Project.Runtime.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace _Project.Runtime.Scripts.Traps
{
    public abstract class Trap : MonoBehaviour
    {
        //Fields
        [SerializeField] protected int _trapDamage = 1;
    
        //UnityAction
        public UnityAction OnHurt;

        //Unity Events
        [SerializeField] protected UnityEvent OnHurtEvent;
    
        private void Awake()
        {
            OnHurtEvent.AddListener(() => OnHurt?.Invoke());
        }

        protected abstract void Hurt(IHealth healthToHurt);
        protected abstract void Hurt(List<IHealth> healthsToHurt);
    }
}
