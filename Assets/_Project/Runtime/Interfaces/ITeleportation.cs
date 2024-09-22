using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITeleportation
{
    public bool CanTeleport { get; }
    
    public void Teleport(Vector3 destination);
}
