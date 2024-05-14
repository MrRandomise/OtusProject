using OtusProject.PlayerInput;
using UnityEngine;

namespace OtusProject.Player
{
    public sealed class Character : MonoBehaviour
    {
        public float Speed;
        public float SpeedRotate;
        public int Health;
        public bool CanMove = true;
        public bool IsAlive = true;
        public Vector3 MoveDirection;

        private Movement _movementCharacter;
        private RotateCharacter _rotateCharacter;

        private void Awake()
        {
            _movementCharacter = new Movement(CanMove, Speed, transform);
            _rotateCharacter = new RotateCharacter(IsAlive, transform);
        }

        private void Update()
        {
            _movementCharacter.Update(MoveDirection);
            _rotateCharacter.Update();
        }
    }
}

