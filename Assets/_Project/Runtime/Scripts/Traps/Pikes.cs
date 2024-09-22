using System;
using System.Collections.Generic;
using _Project.Runtime.Interfaces;
using UnityEngine;

namespace _Project.Runtime.Scripts.Traps
{
    public class Pikes : Trap
    {
        protected override void Hurt(IHealth healthToHurt)
        {
            healthToHurt.TakeDamage(_trapDamage);
            OnHurtEvent.Invoke();
        }

        protected override void Hurt(List<IHealth> healthsToHurt)
        {
            healthsToHurt.ForEach(health => health.TakeDamage(_trapDamage));
            OnHurtEvent.Invoke();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.TryGetComponent(out IHealth health))
            {
                Hurt(health);
            }
        }
    }
}
