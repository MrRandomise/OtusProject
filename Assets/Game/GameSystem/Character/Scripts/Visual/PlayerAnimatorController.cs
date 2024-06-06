using OtusProject.Config.Weapons;
using OtusProject.Player;
using OtusProject.Content;
using OtusProject.Player.Death;
using System;
using UnityEngine;

namespace OtusProject.Visual
{
    public sealed class PlayerAnimatorController : IDisposable
    {
        private readonly CharacterInstaller _character;
        private readonly Animator _animator;
        private readonly DeathPlayer _death;
        private BulletInitInEcsWorld _onBulletRequest;
        private PlayerSetHealth _setHealth;
        public PlayerAnimatorController(CharacterInstaller character, Animator animator, DeathPlayer Death, BulletInitInEcsWorld onBulletRequest)
        {
            _character = character;
            _death = Death;
            _death.OnDeath += DeathAnim;
            _animator = animator;
            _onBulletRequest = onBulletRequest;
            _onBulletRequest.OnBulletEvent += AttackAnim;
        }

        private bool GetMainStateValue()
        {
            if (_character.MoveDirection == Vector3.zero || !_character.CanMove)
                return false;
            return true;
        }

        public void Update()
        {
            //if (_character.CanMove) 
            //{
            //    _animator.SetBool("Move", GetMainStateValue());
            //} 
        }

        private void DeathAnim()
        {
            _animator.SetBool("Move", false);
            _animator.SetTrigger("Death");
        }

        private void AttackAnim()
        {
            if(_character.IsAlive)
            {
                _animator.SetTrigger("Attack");
            }
        }

        public void Dispose()
        {
            _death.OnDeath -= DeathAnim;
            _onBulletRequest.OnBulletEvent -= AttackAnim;
        }
    }
}

