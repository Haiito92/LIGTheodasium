using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Runtime.Scripts.Traps
{
    public class TimberSpawner : MonoBehaviour
    {
        //Prefabs
        [SerializeField] private GameObject _timberPrefab;

        //Spawner
        [SerializeField] private float _spawnRate;
        private Coroutine _spawnCoroutine;
        
        private void Start()
        {
            StartSpawnCoroutine();
        }

        private void SpawnTimber()
        {
            Timber timber = Instantiate(_timberPrefab, transform.position, transform.rotation, transform).GetComponent<Timber>();
        }
        
        private void StartSpawnCoroutine()
        {
            if (_spawnCoroutine == null) _spawnCoroutine = StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                SpawnTimber();
                yield return new WaitForSeconds(1f / _spawnRate);
            }
        }
        
        private void StopSpawnCoroutine()
        {
            if (_spawnCoroutine != null)
            {
                StopCoroutine(_spawnCoroutine);
                _spawnCoroutine = null;
            }
        }
    }
}
