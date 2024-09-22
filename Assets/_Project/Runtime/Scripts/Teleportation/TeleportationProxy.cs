using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationProxy : MonoBehaviour, ITeleportation
{
    [SerializeField] private Teleportation _teleportation;

    public bool CanTeleport => _teleportation.CanTeleport;

    public void Teleport(Vector3 destination)
    {
        _teleportation.Teleport(destination);
    }
}
