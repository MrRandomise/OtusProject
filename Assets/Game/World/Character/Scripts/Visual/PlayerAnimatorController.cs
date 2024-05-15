using OtusProject.Player;
using UnityEngine;

namespace OtusProject.Visual
{
    public sealed class PlayerAnimatorController
    {
        private Character _character;
        private readonly Animator _animator;

        //AnimatorDispatcher animatorDispatcher;

        public PlayerAnimatorController(Character character, Animator animator)
        {
            _character = character;
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
        }
    }
}

