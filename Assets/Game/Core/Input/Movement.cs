using UnityEngine;

namespace OtusProject.PlayerInput
{
    public sealed class Movement
    {
        private readonly bool _canMove;
        private readonly float _speed;
        private readonly Transform _targetTransform;

        public Movement(bool canMove, float speed, Transform transform)
        {
            _canMove = canMove;
            _speed = speed;
            _targetTransform = transform;
        }

        public void Update(Vector3 moveDirection)
        {
            if (!_canMove) return;
            _targetTransform.position += _speed * Time.deltaTime * moveDirection;
        }
    }
}

