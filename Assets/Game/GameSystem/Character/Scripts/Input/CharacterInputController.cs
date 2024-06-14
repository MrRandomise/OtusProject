using System;
using UnityEngine;
using OtusProject.Player;
using Zenject;
using Leopotam.EcsLite.Entities;
using OtusProject.Component;
using OtusProject.Inventary;

namespace OtusProject.PlayerInput
{
    public sealed class CharacterInputController : IDisposable, ITickable
    {
        private readonly InputManager _inputManager;
        private readonly CharacterInstaller _characterInstaller;
        private readonly WeaponInventory _weaponInventory;
        public event Action OnFireRequest;
        private UseKey _lastKey = UseKey.Stop;
        private Entity _character;

        public CharacterInputController(InputManager input, CharacterInstaller character, WeaponInventory weaponInventory)
        {
            _inputManager = input;
            _weaponInventory = weaponInventory;
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
            if (_weaponInventory.TryGetWeapon(code, out var weapon))
            {
                _weaponInventory.ChangeActiveWeapon(code);
            }
        }

        public void Tick()
        {
            _character.GetData<MoveDirection>().Value = GetDirection();
        }

        private Vector3 GetDirection()
        {
            if (_characterInstaller.IsAlive && _characterInstaller.CanMove)
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
            return Vector3.zero;
        }

        public void Dispose()
        {
            _inputManager.OnUseKey -= GetKey;
            _inputManager.OnUseKeyboard -= KeyboardPress;
        }
    }
}

