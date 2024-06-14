using OtusProject.View;
using OtusProject.Weapons;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace OtusProject.Inventary
{
    public sealed class WeaponInventoryView
    {
        private WeaponInventory _inventory;
        private WeaponContainer _container;
        public event Action<Weapon> _OnAddViewWeapon;
        WeaponInventoryView(WeaponInventory inventory, WeaponContainer container)
        {
            _inventory = inventory;
            _container = container;
            _inventory.OnAddWeapon += AddViewContent;
            
        }

        private void AddViewContent(Weapon weapon)
        {
            var view = GameObject.Instantiate(weapon.WeaponConfig.WeaponView, _container.transform.position, Quaternion.identity, _container.Content.transform);
            view.ItemIcon.sprite = weapon.Icon;
            weapon.View = view;
            _OnAddViewWeapon?.Invoke(weapon);
        }
    }
}
