using _Project.Runtime.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace _Project.Runtime.Scripts.Items.Bomb
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _explosionRadius;

        private bool _isActivated = false;
        [SerializeField] private float _timeBeforeExplosion = 1.0f;
        private float _explosionTimer;

        //Actions
        public event UnityAction OnActivation;
        public event UnityAction OnExplosion;
        
        //UnityEvents
        [SerializeField] private UnityEvent OnActivationEvent;
        [SerializeField] private UnityEvent OnExplosionEvent;

        private void Awake()
        {
            OnActivationEvent.AddListener(() => OnActivation?.Invoke());
            OnExplosionEvent.AddListener(() => OnExplosion?.Invoke());
        }

        private void Start()
        {
            ActivateBomb();
        }

        private void Update()
        {
            if (!_isActivated) return;

            _explosionTimer += Time.deltaTime;

            if (_explosionTimer > _timeBeforeExplosion)
            {
                Explode();
            }
        }

        private void ActivateBomb()
        {
            _isActivated = true;
            OnActivationEvent?.Invoke();
        }
        
        private void Explode()
        {
            _isActivated = false;
            
            Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);

            //Collider2D[] cols = new Collider2D[] { };
            
            foreach (Collider2D col in cols)
            {
                if (col.TryGetComponent(out IHealth health))
                {
                    Debug.Log("DoDamage");
                    health.TakeDamage(_damage);
                }
            }
            
            OnExplosionEvent?.Invoke();
            Destroy(gameObject);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            
            Gizmos.DrawWireSphere(transform.position, _explosionRadius);
        }
    }
}
