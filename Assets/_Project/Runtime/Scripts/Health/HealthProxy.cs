using _Project.Runtime.Interfaces;
using UnityEngine;

namespace _Project.Runtime.Scripts.Health
{
    public class HealthProxy : MonoBehaviour, IHealth
    {
        [SerializeField] private Health _health; 
        
        public void TakeDamage(int damage)
        {
            if(_health == null) return;
            
            _health.TakeDamage(damage);
        }
    }
}
