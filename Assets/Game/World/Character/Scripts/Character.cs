using OtusProject.PlayerInput;
using System;
using UnityEngine;

namespace OtusProject.Player
{
    public sealed class Character : MonoBehaviour
    {
        [SerializeField] private int _health = 5;
        private Movement _movementCharacter;
        private RotateCharacter _rotateCharacter;


        public float Speed;
        public float SpeedRotate;
        public bool CanMove = true;
        public bool IsAlive = true;
        public Vector3 MoveDirection;
        public event Action<int> OnSetHealth;

        public int Health
        { 
          get 
          { 
                return _health;
          } 
          set 
          {
                if (value >= 0)
                {
                    _health = value;
                    OnSetHealth?.Invoke(_health);
                }
          }
        }


        private void Awake()
        {
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

