using GluonGui.WorkspaceWindow.Views.WorkspaceExplorer;
using OtusProject.Inventary;
using OtusProject.PlayerInput;
using OtusProject.View;
using System;
using static Codice.Client.Common.Connection.AskCredentialsToUser;

namespace OtusProject.Weapons
{
    public sealed class ChangeViewWeapon : IDisposable
    {
        private WeaponInventory _inventory;
        private WeaponInventoryView _view;
        private ReloadWeapon _reloadWeapon;
        private AttackInputCharacter _attack;
        private const int _alpha = 5;
        ChangeViewWeapon(WeaponInventoryView view, ReloadWeapon reloadWeapon, AttackInputCharacter attack, WeaponInventory weaponInventory)
        {
            _view = view;
            _attack = attack;
            _attack.OnFire += ChangeAmmoView;
            _reloadWeapon = reloadWeapon;
            _reloadWeapon.OnStopReload += ChangeAmmoView;
            _inventory = weaponInventory;
            _inventory.OnChangeActive += Change;
            _view.OnAddView += InitialView;
        }

        private void ChangeAmmoView()
        {
            _view.GetActiveView().ItemCount.text = _inventory.GetActiveWeapon().WeaponConfig.CurrAmmo.ToString();
            _view.GetActiveView().ItemMaxCount.text = _inventory.GetActiveWeapon().WeaponConfig.MaxAmmo.ToString();
        }

        public void Change(Weapon weapon)
        {
            var key = weapon.WeaponConfig.UseKey;
            var view = _view.GetView(key);
            view.OpacityItems();
            _view.ChangeActiveView(key);
            view = _view.GetActiveView();
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