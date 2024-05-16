using OtusProject.Player;
using UnityEngine;

namespace OtusProject.PlayerInput
{
    public sealed class Movement
    {
        private Character _character;
        private Transform _targetTransform;

        public Movement(Character character)
        {
            _character = character;
            _targetTransform = character.transform;
        }

        public void Update(Vector3 moveDirection)
        {
            if (!_character.CanMove) return;
            _targetTransform.position += _character.Speed * Time.deltaTime * moveDirection;
        }
    }
}

