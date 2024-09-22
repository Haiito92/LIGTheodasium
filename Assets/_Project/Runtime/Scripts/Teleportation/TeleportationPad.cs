using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationPad : MonoBehaviour
{
    [SerializeField] private Transform _destination;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ITeleportation teleportationComponent))
        {
            if (teleportationComponent.CanTeleport)
            {
                teleportationComponent.Teleport(_destination.position);
            }
        }
    }
}