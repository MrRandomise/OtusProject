using OtusProject.Inventary;
using OtusProject.PlayerInput;
using OtusProject.View;
using OtusProject.WeaponComponents;
using System;

namespace OtusProject.Weapons
{
    public sealed class WeaponViewPresenter : IDisposable
    {
        private WeaponStorage _inventory;
        private InputManager _attack;
        private ReloadWeaponComponent _reloadWeapon;
        private WeaponInventoryPresenter _weaponPressenter;
        private const int _alpha = 5;

        WeaponViewPresenter(InputManager attack, WeaponStorage weaponInventory, ReloadWeaponComponent reloadWaeapon, WeaponInventoryPresenter weaponPressenter)
        {
            _attack = attack;
            _attack.OnFire += ChangeAmmoView;
            _reloadWeapon = reloadWaeapon;
            _weaponPressenter = weaponPressenter;
            _weaponPressenter.OnAddView += InitialView;
            _reloadWeapon.OnStopReload += ChangeAmmoView;
            _inventory = weaponInventory;
            _inventory.OnChangeActive += Change;
        }

        private void ChangeAmmoView()
        {
            _weaponPressenter.GetActiveView().ItemCount.text = _inventory.GetActiveWeapon().WeaponConfig.CurrAmmo.ToString();
            _weaponPressenter.GetActiveView().ItemMaxCount.text = _inventory.GetActiveWeapon().WeaponConfig.MaxAmmo.ToString();
        }

        public void Change(Weapon weapon)
        {
            var key = weapon.WeaponConfig.UseKey;
            var view = _weaponPressenter.GetView(key);
            view.OpacityItems();
            _weaponPressenter.ChangeActiveView(key);
            view = _weaponPressenter.GetActiveView();
            view.ShowItems();
        }

        public void InitialView(WeaponPanel view)
        {
            var weapon = _inventory.GetActiveWeapon();
            view.ItemIcon.sprite = weapon.Icon;
            view.ItemCount.text = weapon.WeaponConfig.MaxAmmo.ToString();
            view.ItemMaxCount.text = weapon.WeaponConfig.MaxAmmo.ToString();
            view.Key.text = weapon.WeaponConfig.UseKey.ToString().Remove(0, _alpha);
            view.OpacityItems();
        }

        public void Dispose()
        {
            _inventory.OnChangeActive -= Change;
            _attack.OnFire -= ChangeAmmoView;
            _reloadWeapon.OnStopReload -= ChangeAmmoView;
        }
    }
}