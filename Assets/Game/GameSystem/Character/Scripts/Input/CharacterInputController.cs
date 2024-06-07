using System;
using UnityEngine;
using OtusProject.Content;
using Zenject;
using OtusProject.Weapons;
using Leopotam.EcsLite.Entities;
using OtusProject.Component;

namespace OtusProject.PlayerInput
{
    public sealed class CharacterInputController : IDisposable, ITickable
    {
        private readonly InputManager _inputManager;
        private readonly CharacterInstaller _characterInstaller;
        public event Action OnFireRequest;
        public event Action<IWeapon> OnChangeWeapon;
        private UseKey _lastKey = UseKey.Stop;
        private Entity _character;

        public CharacterInputController(InputManager input, CharacterInstaller character)
        {
            _inputManager = input;
            _inputManager.OnUseKey += GetKey;
            _inputManager.OnUseKeyboard += KeyboardPress;
            _characterInstaller = character;
            _character = _characterInstaller.GetComponent<Entity>();
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
            foreach (var item in _characterInstaller.ListWeapon)
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
            _character.GetData<MoveDirection>().Value = GetDirection();
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

