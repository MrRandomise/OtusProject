using OtusProject.Inventary;
using OtusProject.PlayerInput;
using OtusProject.View;
using System;

namespace OtusProject.Weapons
{
    public sealed class ChangeViewWeapon : IDisposable
    {
        private WeaponInventory _inventory;
        private ReloadWeapon _reloadWeapon;
        private AttackInputCharacter _attack;
        private WeaponPanel _weaponPanel = null;
        private WeaponInventoryView _weaponView;
        private const int _alpha = 5;

        ChangeViewWeapon(ReloadWeapon reloadWeapon, AttackInputCharacter attack, WeaponInventory weaponInventory, WeaponInventoryView weaponView)
        {
            _attack = attack;
            _attack.OnFire += ChangeAmmoView;
            _reloadWeapon = reloadWeapon;
            _reloadWeapon.OnStopReload += ChangeAmmoView;
            _inventory = weaponInventory;
            _inventory.OnChangeActive += Change;
            _inventory.OnAddWeapon += InitialView;
            _weaponView = weaponView;
            _weaponView._OnAddViewWeapon += InitialView;
        }

        private void ChangeAmmoView()
        {
            var weapon = _inventory.GetActiveWeapon();
            weapon.View.ItemCount.text = weapon.WeaponConfig.CurrAmmo.ToString();
            weapon.View.ItemMaxCount.text = weapon.WeaponConfig.MaxAmmo.ToString();
        }

        public void Change(Weapon weapon)
        {
            var view = weapon.View;
            if(_weaponPanel != null)
            {
                _weaponPanel.OpacityItems();
            }
            view.ShowItems();
            _weaponPanel = view;
        }

        public void InitialView(Weapon weapon)
        {
            weapon.View.ItemIcon.sprite = weapon.Icon;
            weapon.View.ItemCount.text = weapon.WeaponConfig.MaxAmmo.ToString();
            weapon.View.ItemMaxCount.text = weapon.WeaponConfig.MaxAmmo.ToString();
            weapon.View.Key.text = weapon.WeaponConfig.UseKey.ToString().Remove(0, _alpha);
            Change(weapon);
        }

        public void Dispose()
        {
            _inventory.OnChangeActive -= Change;
            _attack.OnFire -= ChangeAmmoView;
            _reloadWeapon.OnStopReload -= ChangeAmmoView;
        }
    }
}