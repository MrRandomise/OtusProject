using OtusProject.Player;
using OtusProject.Player.Death;
using System;
using UnityEngine;

namespace OtusProject.Visual
{
    public sealed class PlayerAnimatorController : IDisposable
    {
        private readonly Character _character;
        private readonly Animator _animator;
        private readonly DeathPlayer _death;

        public PlayerAnimatorController(Character character, Animator animator, DeathPlayer Death)
        {
            _character = character;
            _death = Death;
            _death.OnDeath += DeathAnim;
            _animator = animator;
        }

        private bool GetMainStateValue()
        {
            if (_character.MoveDirection == Vector3.zero || !_character.CanMove)
                return false;
            return true;
        }

        public void Update()
        {
            if (!_character.IsAlive) return;
            _animator.SetBool("Move", GetMainStateValue());
            if(_character.CurrentWeapon.FireRequired)
            {
                _animator.SetTrigger("Attack");
            }
        }

        private void DeathAnim()
        {
            _animator.SetTrigger("Death");
        }

        public void Dispose()
        {
            _death.OnDeath -= DeathAnim;
        }
    }
}

