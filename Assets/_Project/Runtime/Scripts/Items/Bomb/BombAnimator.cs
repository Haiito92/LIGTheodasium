using System;
using UnityEngine;

namespace _Project.Runtime.Scripts.Items.Bomb
{
    public class BombAnimator : MonoBehaviour
    {
        //BombRef
        [SerializeField] private Bomb _bomb;
        
        //Anim
        [SerializeField] private Animator _animator;
        [SerializeField] private string _activationAnimName;
        [SerializeField] private string _explosionAnimName;
        
        
        private void OnActivationEvent() => _animator.Play(_activationAnimName);

        private void OnExplosionEvent()
        {
            _animator.Play(_explosionAnimName);
        }
        
        private void OnEnable()
        {
            _bomb.OnActivation += OnActivationEvent;
            _bomb.OnExplosion += OnExplosionEvent;
        }

        private void OnDisable()
        {
            _bomb.OnActivation -= OnActivationEvent;
            _bomb.OnExplosion -= OnExplosionEvent;
        }
    }
}
