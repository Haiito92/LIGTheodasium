using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Runtime.Scripts.UI
{
    using Scripts.Health;
    
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Health _health;

        [SerializeField] private GameObject _healthPointPrefab;
        private List<HealthPoint> _healthPoints;

        private void Awake()
        {
            _healthPoints = new List<HealthPoint>();
        }

        private void Start()
        {
            for (int i = 0; i < _health.MaxHealth; i++)
            {
                HealthPoint healthPoint = Instantiate(_healthPointPrefab, this.transform).GetComponent<HealthPoint>();
                
                if(healthPoint == null) continue;
                
                _healthPoints.Add(healthPoint);
            }
            
            UpdateHealthBar(_health.CurrentHealth);
        }

        private void UpdateHealthBar(int currentHealth)
        {
            for (int i = 0; i < _healthPoints.Count; i++)
            {
                _healthPoints[i].UpdateSprite( i < currentHealth);
            }
        }
        
        private void OnEnable()
        {
            _health.OnCurrentHealthChanged += UpdateHealthBar;
        }

        private void OnDisable()
        {
            _health.OnCurrentHealthChanged -= UpdateHealthBar;
        }
    }
}
