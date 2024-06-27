using OtusProject.Inventary;
using System;
using UnityEngine;

namespace OtusProject.PlayerInput
{
    public sealed class ChangeWeaponController : IDisposable
    {
        private readonly InputManager _inputManager;
        private readonly WeaponStorage _weaponInventory;
        ChangeWeaponController(InputManager inputManager, WeaponStorage weaponInventory)
        {
            _inputManager = inputManager;
            _weaponInventory = weaponInventory;
            _inputManager.OnUseKeyNum += KeyboardPress;
        }

        public void KeyboardPress(KeyCode code)
        {
            if (_weaponInventory.TryGetWeapon(code, out var weapon))
            {
                _weaponInventory.ChangeActiveWeapon(code);
            }
        }

        public void Dispose()
        {
            _inputManager.OnUseKeyNum -= KeyboardPress;
        }
    }
}