using System.Collections;
using UnityEngine;

public class Teleportation : MonoBehaviour, ITeleportation
{
    [SerializeField] private bool _canTeleport = true;
    [SerializeField] private float _teleportCooldown = 0.2f;
    [SerializeField] private Transform _teleportedTransform;
    
    public bool CanTeleport { get => _canTeleport;}

    public void Teleport(Vector3 destination)
    {
        _canTeleport = false;
        _teleportedTransform.position = destination;
        StartCoroutine(TeleportCooldown());
    }

    private IEnumerator TeleportCooldown()
    {
        yield return new WaitForSeconds(_teleportCooldown);
        _canTeleport = true;
    }
}
