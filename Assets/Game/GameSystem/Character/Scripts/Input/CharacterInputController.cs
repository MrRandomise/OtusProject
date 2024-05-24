using System;
using UnityEngine;
using OtusProject.Player;
using Zenject;
using OtusProject.Config.Weapons;
using OtusProject.Weapons;

namespace OtusProject.PlayerInput
{
    public sealed class CharacterInputController : IDisposable, ITickable
    {
        private readonly InputManager _inputManager;
        private readonly Character _character;
        public event Action OnFireRequest;
        public event Action<IWeapon> OnChangeWeapon;
        private bool _isMoving = false;
        public CharacterInputController(InputManager input, Character character)
        {
            _inputManager = input;
            _inputManager.OnUseMouse += GetKey;
            _inputManager.OnUseKeyboard += KeyboardPress;
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

        public void KeyboardPress(KeyCode code)
        {
            var prevWeapon = GetItem(code);
            if (prevWeapon != null )
            {
                OnChangeWeapon?.Invoke(prevWeapon);
            }
        }

        private IWeapon GetItem(KeyCode code)
        {
            foreach (var item in _character.ListWeapon)
            {
                if (item.Key == code)
                {
                    return item.Value;
                }
            }
            return null;
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
            _inputManager.OnUseMouse -= GetKey;
            _inputManager.OnUseKeyboard -= KeyboardPress;
        }
    }
}

