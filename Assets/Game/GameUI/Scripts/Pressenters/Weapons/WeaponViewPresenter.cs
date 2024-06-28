using OtusProject.Inventary;
using OtusProject.PlayerInput;
using OtusProject.WeaponComponents;
using OtusProject.View;
using UnityEngine;

namespace OtusProject.Weapons
{
    public sealed class WeaponViewPresenter
    {
        private WeaponStorage _inventory;
        private Weapon _weapon;
        private InputManager _attack;
        private ReloadWeaponComponent _reloadWeapon;
        private WeaponStoragePresenter _weaponPressenter;
        private const int _alpha = 5;

        WeaponViewPresenter(InputManager attack, WeaponStorage weaponInventory, ReloadWeaponComponent reloadWaeapon, WeaponStoragePresenter weaponPressenter)
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

        public void Change(Weapon weapon, KeyCode keys)
        {
            WeaponPanel view;
            if(_weapon != null )
            {
                var key = _weapon.WeaponConfig.UseKey;
                view = _weaponPressenter.GetView(key);
                view.OpacityItems();
                _weaponPressenter.ChangeActiveView(key);
            }
            view = _weaponPressenter.GetView(keys);
            view.ShowItems();
            _weapon = weapon;
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