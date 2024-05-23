using System;
using UnityEngine;
using OtusProject.Player;
using Zenject;

namespace OtusProject.PlayerInput
{
    public sealed class CharacterInputController : IDisposable, ITickable
    {
        private readonly InputManager _inputManager;
        private readonly Character _character;
        public event Action OnFireRequest;
        public event Action<KeyCode> OnChangeWeapon;

        private bool _isMoving = false;
        public CharacterInputController(InputManager input, Character character)
        {
            _inputManager = input;
            _inputManager.OnUseKey += GetKey;
            _inputManager.OnKeyboard += UseKeyBoard;
            _character = character;
        }

        private void GetKey(UseKey key)
        {
            if (key == UseKey.Fire)
            {
                OnFireRequest?.Invoke();
            }
            if(key == UseKey.Move) 
            {
                _isMoving = true;
            }
            else if (key == UseKey.Stop)
            {
                _isMoving = false;
                _character.MoveDirection = Vector3.zero;
            }
        }
        private void UseKeyBoard(KeyCode code)
        {
            OnChangeWeapon?.Invoke(code);
        }

        public void Tick()
        {
            if(_isMoving)
            {
                _character.MoveDirection = _character.transform.forward;
            }
            
        }

        public void Dispose()
        {
            _inputManager.OnUseKey -= GetKey;
        }
    }
}

