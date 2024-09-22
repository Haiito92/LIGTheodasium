using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractableProxy : MonoBehaviour,IAttractable
{
    [SerializeField] private Attractable _attractable;

    public Rigidbody2D AttractedRB { get => _attractable.AttractedRB; set => AttractedRB = value; }
}
