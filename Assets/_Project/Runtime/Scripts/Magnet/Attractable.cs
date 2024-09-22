using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractable : MonoBehaviour,IAttractable
{
    [SerializeField] private Rigidbody2D _attractedRB;
    
    public Rigidbody2D AttractedRB { get => _attractedRB; set => _attractedRB = value; }
}
