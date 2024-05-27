using OtusProject.PlayerInput;
using OtusProject.Weapons;
using System.Collections.Generic;
using UnityEngine;
using OtusProject.ItemSystem;

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
        public IWeapon CurrentWeapon;
        [SerializeReference] public IItems Component;
        public Dictionary<KeyCode, IWeapon> ListWeapon = new Dictionary<KeyCode, IWeapon>();
        private Movement _movementCharacter;
        private RotateCharacter _rotateCharacter;

        private void Awake()
        {
            FirstWeapon();
            _movementCharacter = new Movement(this);
            _rotateCharacter = new RotateCharacter(this);
        }

        private void Update()
        {
            _movementCharacter.Update(MoveDirection);
            _rotateCharacter.Update();
        }

        private void FirstWeapon()
        {
            Component.BuyItem();
        }
    }
}

