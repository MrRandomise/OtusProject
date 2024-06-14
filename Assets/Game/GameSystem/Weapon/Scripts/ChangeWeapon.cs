using OtusProject.Inventary;
using System;

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
            if (weapon != null)
            {
                weapon.gameObject.SetActive(false);
            }
            var newWeapon = _inventory.GetActiveWeapon();
            newWeapon.gameObject.SetActive(true);
        }

        public void Dispose()
        {
            _inventory.OnChangeActive -= Change;
        }
    }
}