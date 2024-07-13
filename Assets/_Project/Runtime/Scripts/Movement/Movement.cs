using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private bool _isPlayer;

    //IS PLAYER VARIABLES
    [SerializeField] private InputActionReference _movementInput;

    //IS AI VARIABLES
    //patrol
    [SerializeField] private Transform[] _waypoints;
    private Transform _target;
    private int _destPoint;


    //USED IN BOTH VARIABLES
    [SerializeField] private float _speed;

    private Vector2 _direction;

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
        transform.position = (Vector2)transform.position + _direction * _speed * Time.fixedDeltaTime;
    }

    private void SetWalkDirection(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            _direction = ctx.ReadValue<Vector2>();
        }
        else if(ctx.canceled)
        {
            _direction = Vector2.zero;
        }
    }

    private void Patrol()
    {
        _direction = _target.position - transform.position;
        transform.position = (Vector2)transform.position + _direction.normalized * _speed * Time.fixedDeltaTime;

        if(Vector2.Distance(transform.position, _target.position) < 0.3f)
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

    private void OnValidate()
    {
        if (_isPlayer)
        {

        }
        else
        {
            //_waypoints.Serialize(this);
        }
    }
}
