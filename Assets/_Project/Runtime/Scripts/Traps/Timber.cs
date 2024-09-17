using System;
using System.Collections.Generic;
using _Project.Runtime.Interfaces;
using UnityEngine;

namespace _Project.Runtime.Scripts.Traps
{
    public class Timber : Trap
    {
        //LifeTime
        [SerializeField] private float _lifeTime = 1f;
        private float _lifeTimer;
        private bool _isLifeTimerRunning;
        
        //Movement
        [SerializeField] private float speed;

        private void Start()
        {
            _isLifeTimerRunning = true;
        }

        private void Update()
        {
            if (_isLifeTimerRunning && _lifeTimer < _lifeTime)
            {
                _lifeTimer += Time.deltaTime;
            }

            if (_isLifeTimerRunning && _lifeTimer >= _lifeTime)
            {
                DestroyTimber();
            }
        }

        private void FixedUpdate()
        {
            MoveTimber();
        }

        private void MoveTimber()
        {
            transform.position = (Vector2)transform.position + Vector2.down * (speed * Time.fixedDeltaTime);
        }
        
        #region Trap Inheritance
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
        #endregion

        private void DestroyTimber()
        {
            _isLifeTimerRunning = false;
            Destroy(this);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IHealth health))
            {
                Hurt(health);
                
            }
            
            DestroyTimber();
        }
    }
}
