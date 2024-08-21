using System.Collections;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [SerializeField] private bool _canTeleport = true;
    [SerializeField] private float _teleportCooldown = 0.2f;

    public bool CanTeleport { get => _canTeleport;}

    public void Teleport(Vector3 destination)
    {
        _canTeleport = false;
        transform.position = destination;
        StartCoroutine(TeleportCooldown());
    }

    private IEnumerator TeleportCooldown()
    {
        yield return new WaitForSeconds(_teleportCooldown);
        _canTeleport = true;
    }
}
