using _Project.Runtime.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    [SerializeField] private int _damages;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.TryGetComponent<IHealth>(out IHealth health))
        {
            Debug.Log("Collision avec vie");
            health.TakeDamage(_damages);
        }

        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}