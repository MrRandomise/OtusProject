using OtusProject.View;
using OtusProject.Weapons;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace OtusProject.Inventary
{
    public sealed class WeaponInventoryView : IDisposable
    {
        private Dictionary<KeyCode, WeaponPanel> _view = new Dictionary<KeyCode, WeaponPanel>();
        private WeaponInventory _inventory;
        private WeaponPanel ActiveView;
        private WeaponContainer _container;
        public event Action<WeaponPanel> OnAddView;
        WeaponInventoryView(WeaponInventory inventory, WeaponContainer container)
        {
            _inventory = inventory;
            _container = container;
            _inventory.OnAddWeapon += AddViewContent;
        }

        private void AddViewContent(Weapon weapon)
        {
            var view = GameObject.Instantiate(weapon.WeaponView, _container.transform.position, Quaternion.identity, _container.Content.transform);
            view.ItemIcon.sprite = weapon.Icon;
            _view.Add(weapon.WeaponConfig.UseKey, view);
            ChangeActiveView(weapon.WeaponConfig.UseKey);
            OnAddView?.Invoke(GetActiveView());
        }

        public WeaponPanel GetActiveView() => ActiveView;

        public WeaponPanel GetView(KeyCode key) => _view[key];
        public void ChangeActiveView(KeyCode key) => ActiveView = _view[key];

        public void Dispose()
        {
            _inventory.OnAddWeapon -= AddViewContent;
        }
    }
}
