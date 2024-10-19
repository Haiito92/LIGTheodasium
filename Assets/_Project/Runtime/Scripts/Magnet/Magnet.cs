using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Magnet : MonoBehaviour
{

    [SerializeField] float _attractionForce;
    // [SerializeField] GameObject _player;
    private IAttractable _attractablePlayer;
    private Rigidbody2D _playerRb;
    private bool _isAttractingPlayer;
    private Vector2 _playerAttractionDirection;

    [SerializeField] private CircleCollider2D _collider2D;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IAttractable attractable) && collision.CompareTag("Player"))
        {
            _attractablePlayer = attractable;
            _playerRb = _attractablePlayer.AttractedRB;
            _isAttractingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IAttractable attractable) && collision.gameObject.CompareTag("Player"))
        {
            _playerRb.velocity = Vector2.zero;
            _playerRb = null;
            _attractablePlayer = null;
            _isAttractingPlayer = false;
        }
        /*_playerAttractionDirection = Vector2.zero;*/
    }

    private void FixedUpdate()
    {
        if(_isAttractingPlayer)
        {
            _playerAttractionDirection = (transform.position - _playerRb.transform.position).normalized;
            _playerRb.velocity = new Vector2(_playerAttractionDirection.x, _playerAttractionDirection.y) * _attractionForce;
        }
    }

    private void OnDrawGizmos()
    {
        if (_collider2D != null)
        {
            Gizmos.DrawWireSphere(transform.position, _collider2D.radius);
        }
    }
}
