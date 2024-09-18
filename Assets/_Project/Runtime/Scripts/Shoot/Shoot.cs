using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] private bool _isPlayer;
    [SerializeField] private bool _isStatic;
    [SerializeField] private Vector2[] _shootingDirections;
    [SerializeField] private float _timeBetweenShoot = 1.0f;

    [SerializeField] private InputActionReference _shootInput;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private float _spawnOffset = 0.5f;

    private Movement _movementComponent;

    private void Start()
    {
        if(TryGetComponent<Movement>(out Movement movementComponent))   
        {
            _movementComponent = movementComponent;
            return;
        }

        if(!_isPlayer && _movementComponent == null)
        {
            StartCoroutine(ShootingCoroutine());
        }
    }

    private void OnEnable()
    {
        if(_isPlayer)
        {
            _shootInput.action.started += InstanciateProjectile;
        }
    }

    private void OnDisable()
    {
        if(_isPlayer)
        {
            _shootInput.action.started -= InstanciateProjectile;
        }
    }

    private void InstanciateProjectile(InputAction.CallbackContext ctx)
    {
        GameObject instantiatedProjectile = Instantiate(_projectilePrefab, (Vector2)transform.position + _movementComponent.Direction * _spawnOffset, Quaternion.identity);
        
        instantiatedProjectile.GetComponent<ProjectileMovement>().Direction = _movementComponent.Direction;
    }

    private IEnumerator ShootingCoroutine()
    {
        while(true)
        {
            for(int i = 0; i < _shootingDirections.Length; i++)
            {
                GameObject instantiatedProjectile = Instantiate(_projectilePrefab, (Vector2)transform.position + _shootingDirections[i] * _spawnOffset, Quaternion.identity);

                instantiatedProjectile.GetComponent<ProjectileMovement>().Direction = _shootingDirections[i];
            }

            yield return new WaitForSeconds(_timeBetweenShoot);
        }
    }
}
