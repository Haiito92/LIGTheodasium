using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private bool _isPlayer;
    [SerializeField] private Transform _movingTransform;

    //IS PLAYER VARIABLES
    [SerializeField] private InputActionReference _movementInput;
    private bool _isMoving;

    //IS AI VARIABLES
    //patrol
    [SerializeField] private Transform[] _waypoints;
    private Transform _target;
    private int _destPoint;


    //USED IN BOTH VARIABLES
    [SerializeField] private float _speed;

    private Vector2 _direction;

    #region PROPERTIES

    public Vector2 Direction => _direction;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if (!_isPlayer)
        {
            _target = _waypoints[0];
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_isPlayer)
        {
            Walk();
        }
        else
        {
            Patrol();
        }
    }

    private void Walk()
    {
        if(_isMoving)
        {
            _movingTransform.position = (Vector2)_movingTransform.position + _direction * _speed * Time.fixedDeltaTime;
        }
    }

    private void SetWalkDirection(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            _direction = ctx.ReadValue<Vector2>();
            _isMoving = true;
        }
        else if(ctx.canceled)
        {
            _isMoving= false;
        }
    }

    private void Patrol()
    {
        _direction = _target.position - _movingTransform.position;
        _movingTransform.position = (Vector2)_movingTransform.position + _direction.normalized * _speed * Time.fixedDeltaTime;

        if(Vector2.Distance(_movingTransform.position, _target.position) < 0.3f)
        {
            _destPoint = (_destPoint + 1) % _waypoints.Length;
            _target = _waypoints[_destPoint];
        }
    }

    private void OnEnable()
    {
        if (_isPlayer)
        {
            _movementInput.action.performed += SetWalkDirection;
            _movementInput.action.canceled += SetWalkDirection;
        }
    }

    private void OnDisable()
    {
        if( _isPlayer)
        {
            _movementInput.action.performed -= SetWalkDirection;
            _movementInput.action.canceled -= SetWalkDirection;
        }
    }
}
