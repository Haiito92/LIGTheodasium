using _Project.Runtime.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace _Project.Runtime.Scripts.Health
{
    public class Health : MonoBehaviour, IHealth
    {
        //Fields
        [Header("Fields"), Space(5)]
        [SerializeField] private int _maxHealth = 10;
        private int _currentHealth;
        
        //Actions

        public event UnityAction<int> OnCurrentHealthChanged;
        
        //UnityEvents
        [Header("Events"), Space(5)]
        
        [SerializeField] private UnityEvent OnDamageTakenEvent;
        [SerializeField] private UnityEvent OnDeathEvent;
        
        //Properties
        
        #region Properties

        public int MaxHealth => _maxHealth;

        public int CurrentHealth 
        { 
            get => _currentHealth;
            private set
            {
                _currentHealth = Mathf.Clamp(value, 0, _maxHealth);
                OnCurrentHealthChanged?.Invoke(_currentHealth);
            }

        }
        #endregion
        
        private void Awake()
        {
            CurrentHealth = MaxHealth;
        }

        public void TakeDamage(int damage)
        {
            if(damage <= 0) return;

            CurrentHealth -= damage;

            OnDamageTakenEvent?.Invoke();
            
            if (CurrentHealth <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            OnDeathEvent?.Invoke();
        }
    }
}
