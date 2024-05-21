using OtusProject.Config.Weapon;
using OtusProject.PlayerInput;
using System;
using UnityEngine;

namespace OtusProject.Player
{
    public sealed class Character : MonoBehaviour
    {
        public int Health = 5;
        public float Speed;
        public float SpeedRotate;
        public bool CanMove = true;
        public bool IsAlive = true;
        public Vector3 MoveDirection;
        public Weapon CurrentWeapon;
        private Movement _movementCharacter;
        private RotateCharacter _rotateCharacter;

        private void Awake()
        {
            _movementCharacter = new Movement(this);
            _rotateCharacter = new RotateCharacter(this);
            CurrentWeapon.UseItem();
        }

        private void Update()
        {
            _movementCharacter.Update(MoveDirection);
            _rotateCharacter.Update();
        }
    }
}

