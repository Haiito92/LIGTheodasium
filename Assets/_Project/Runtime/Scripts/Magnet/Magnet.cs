using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Magnet : MonoBehaviour
{

    [SerializeField] float _attractionForce;
    [SerializeField] GameObject _player;
    [SerializeField] Rigidbody2D _playerRb;
    private bool _isAttractingPlayer;
    private Vector2 _playerAttractionDirection;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == _player)
        {
            _isAttractingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == _player)
        {
            _isAttractingPlayer = false;
        }

        /*_playerAttractionDirection = Vector2.zero;*/
        _playerRb.velocity = Vector2.zero;
    }

    private void FixedUpdate()
    {
        if(_isAttractingPlayer)
        {
            _playerAttractionDirection = (transform.position - _player.transform.position).normalized;
            _playerRb.velocity = new Vector2(_playerAttractionDirection.x, _playerAttractionDirection.y) * _attractionForce;
        }
    }

}
