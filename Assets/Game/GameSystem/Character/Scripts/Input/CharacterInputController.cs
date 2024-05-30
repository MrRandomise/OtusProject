using System;
using UnityEngine;
using OtusProject.Player;
using Zenject;
using OtusProject.Weapons;

namespace OtusProject.PlayerInput
{
    public sealed class CharacterInputController : IDisposable, ITickable
    {
        private readonly InputManager _inputManager;
        private readonly Character _character;
        public event Action OnFireRequest;
        public event Action<IWeapon> OnChangeWeapon;
        private UseKey _lastKey = UseKey.Stop;
        public CharacterInputController(InputManager input, Character character)
        {
            _inputManager = input;
            _inputManager.OnUseKey += GetKey;
            _inputManager.OnUseKeyboard += KeyboardPress;
            _character = character;
        }

        public void GetKey(UseKey key)
        {
            if (key == UseKey.Fire)
            {
                OnFireRequest?.Invoke();
            }
            _lastKey = key;
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
            _character.MoveDirection = GetDirection();
        }

        private Vector3 GetDirection()
        {
            switch (_lastKey)
            {
                case UseKey.Left:
                    return -_character.transform.right;
                case UseKey.Right:
                    return _character.transform.right;
                case UseKey.Forward:
                    return _character.transform.forward;
                case UseKey.Backward:
                    return -_character.transform.forward;
                default:
                    return Vector3.zero;
            }
        }

        public void Dispose()
        {
            _inputManager.OnUseKey -= GetKey;
            _inputManager.OnUseKeyboard -= KeyboardPress;
        }
    }
}

