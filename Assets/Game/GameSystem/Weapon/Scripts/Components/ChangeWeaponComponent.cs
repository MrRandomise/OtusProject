using OtusProject.Inventary;
using System;

namespace OtusProject.Weapons
{
    public sealed class ChangeWeaponComponent : IDisposable
    {
        private WeaponStorage _inventory;

        ChangeWeaponComponent(WeaponStorage inventory)
        {
            _inventory = inventory;
            _inventory.OnChangeActive += Change;
        }

        public void Change(Weapon weapon)
        {
            weapon.gameObject.SetActive(false);
            var newWeapon = _inventory.GetActiveWeapon();
            newWeapon.gameObject.SetActive(true);
        }

        public void Dispose()
        {
            _inventory.OnChangeActive -= Change;
        }
    }
}