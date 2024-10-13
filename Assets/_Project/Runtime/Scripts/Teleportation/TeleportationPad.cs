using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationPad : MonoBehaviour
{
    [SerializeField] private Transform _destination;
    [SerializeField] private ParticleSystem _particleSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _particleSystem.Play();

        if (collision.TryGetComponent(out ITeleportation teleportationComponent))
        {
            if (teleportationComponent.CanTeleport)
            {
                teleportationComponent.Teleport(_destination.position);
            }

            if(collision.TryGetComponent(out ParticleSystem particleSystem))
            {
                particleSystem.Play();
            }
        }
    }
}