using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedModifyGround : MonoBehaviour
{
    [SerializeField] private bool _isSlowing;
    [SerializeField] private bool _isSpeeding;
    [SerializeField] private float _strenght;

    private float _objectBaseSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Movement>(out Movement movementComponent))
        {
            _objectBaseSpeed = movementComponent._speed;

            if (_isSlowing)
            {
                movementComponent._speed /= _strenght;
            }
            else if (_isSpeeding)
            {
                movementComponent._speed *= _strenght;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Movement>(out Movement movementComponent))
        {
            movementComponent._speed = _objectBaseSpeed;
        }
    }
}
