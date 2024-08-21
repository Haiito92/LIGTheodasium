using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Vector2 _direction;

    #region PROPERTIES
    public Vector2 Direction {  get { return _direction; } set { _direction = value; } }
    #endregion

    void FixedUpdate()
    {
        transform.position = (Vector2)transform.position + _direction * _speed * Time.fixedDeltaTime;
    }
}
