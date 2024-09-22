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
        public event UnityAction OnDamageTaken;
        public event UnityAction OnHealed;
        public event UnityAction OnDeath;
        
        //UnityEvents
        [Header("Events"), Space(5)]
        
        [SerializeField] private UnityEvent OnDamageTakenEvent;
        [SerializeField] private UnityEvent OnHealedEvent;
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

        private bool IsAlive => _currentHealth > 0;
        #endregion
        
        private void Awake()
        {
            CurrentHealth = MaxHealth;
            
            OnDamageTakenEvent.AddListener(() => OnDamageTaken?.Invoke());
            OnHealedEvent.AddListener(() => OnHealed?.Invoke());
            OnDeathEvent.AddListener(() => OnDeath?.Invoke());
        }

        public void TakeDamage(int damage)
        {
            if(damage <= 0 || !IsAlive) return;

            CurrentHealth -= damage;

            OnDamageTakenEvent?.Invoke();
            
            Debug.Log("Took damage. Health left : " + CurrentHealth);
            
            if (CurrentHealth <= 0)
            {
                Die();
            }
        }

        public void Heal(int heal)
        {
            if(!IsAlive) return;

            CurrentHealth += heal;
            
            OnHealedEvent?.Invoke();            
        } 
        
        private void Die()
        {
            OnDeathEvent?.Invoke();
            //Debug.Log("Dead");
        }

        public void DestroyHealthObject(GameObject inGameObject) => Destroy(inGameObject);
    }
}
