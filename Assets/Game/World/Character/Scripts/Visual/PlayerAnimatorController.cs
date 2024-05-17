using OtusProject.Player;
using OtusProject.Player.Death;
using OtusProject.PlayerInput;
using OtusProject.PoolsSystem;
using System;
using UnityEngine;

namespace OtusProject.Visual
{
    public sealed class PlayerAnimatorController : IDisposable
    {
        private readonly Character _character;
        private readonly Animator _animator;
        private readonly DeathPlayer _death;
        private PoolsComponent _pools;
        public PlayerAnimatorController(Character character, Animator animator, DeathPlayer Death, PoolsComponent pools)
        {
            _character = character;
            _death = Death;
            _death.OnDeath += DeathAnim;
            _animator = animator;
            _pools = pools;
            _pools.OnBulletEvent += AttackAnim;
        }

        private bool GetMainStateValue()
        {
            if (_character.MoveDirection == Vector3.zero || !_character.CanMove)
                return false;
            return true;
        }

        public void Update()
        {
            if (_character.CanMove) 
            {
                _animator.SetBool("Move", GetMainStateValue());
            } 
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
            _pools.OnBulletEvent -= AttackAnim;
        }
    }
}

