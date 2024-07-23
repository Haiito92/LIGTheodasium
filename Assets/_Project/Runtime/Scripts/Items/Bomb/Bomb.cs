using _Project.Runtime.Interfaces;
using NaughtyAttributes;
using UnityEngine;

namespace _Project.Runtime.Scripts.Items.Bomb
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _explosionRadius;

        [Button]
        private void Explode()
        {
            Collider2D[] cols = new Collider2D[] { };
            Physics2D.OverlapCircleNonAlloc(transform.position, _explosionRadius, cols);

            foreach (Collider2D col in cols)
            {
                if (col.TryGetComponent(out IHealth health))
                {
                    health.TakeDamage(_damage);
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            
            Gizmos.DrawWireSphere(transform.position, _explosionRadius);
        }
    }
}
