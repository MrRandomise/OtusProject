using OtusProject.Inventary;
using System;
using UnityEngine;

namespace OtusProject.Weapons
{
    public sealed class ChangeWeapon : IDisposable
    {
        private WeaponInventory _inventory;

        ChangeWeapon(WeaponInventory inventory)
        {
            _inventory = inventory;
            _inventory.OnChangeActive += Change;
        }

        public void Change(Weapon weapon)
        {
            weapon.gameObject.SetActive(false);
            weapon = _inventory.GetActiveWeapon();
            weapon.gameObject.SetActive(true);
        }

        public void Dispose()
        {
            _inventory.OnChangeActive -= Change;
        }
    }
}