using _Project.Runtime.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    [SerializeField] private int _damages;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<IHealth>(out IHealth health))
        {
            health.TakeDamage(_damages);
        }
    }
}
