using OtusProject.Config.Weapons;
using OtusProject.PlayerInput;
using System.Collections.Generic;
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
        public Transform WeaponPoint;
        private Movement _movementCharacter;
        private RotateCharacter _rotateCharacter;

        private void Awake()
        {
            CurrentWeapon.WeaponConfig.CurrAmmo = CurrentWeapon.WeaponConfig.MaxAmmo;
            CurrentWeapon.Active = true;
            _movementCharacter = new Movement(this);
            _rotateCharacter = new RotateCharacter(this);
        }

        private void Update()
        {
            _movementCharacter.Update(MoveDirection);
            _rotateCharacter.Update();
        }
    }
}

