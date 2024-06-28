using OtusProject.Inventary;
using System;
using UnityEngine;

namespace OtusProject.Weapons
{
    public sealed class ChangeWeaponComponent : IDisposable
    {
        private WeaponStorage _inventory;
        private Weapon _weapon;
        ChangeWeaponComponent(WeaponStorage inventory)
        {
            _inventory = inventory;
            _inventory.OnChangeActive += Change;
        }

        public void Change(Weapon weapon, KeyCode key)
        {
            if(_weapon != null )
            {
                _weapon.gameObject.SetActive(false);
            }
            weapon.gameObject.SetActive(true);
            _weapon = weapon;
        }

        public void Dispose()
        {
            _inventory.OnChangeActive -= Change;
        }
    }
}