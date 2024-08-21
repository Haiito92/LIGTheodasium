using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLifetime : MonoBehaviour
{
    [SerializeField] private float _lifetime;
    private float _timer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoDestroy());
    }
    
    private IEnumerator AutoDestroy()
    {
        while(_timer < _lifetime)
        {
            _timer += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }

}
