using OtusProject.View;
using OtusProject.Weapons;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace OtusProject.Inventary
{
    public sealed class WeaponStoragePresenter : IDisposable
    {
        private Dictionary<KeyCode, WeaponPanel> _view = new Dictionary<KeyCode, WeaponPanel>();
        private WeaponStorage _inventory;
        private WeaponPanel _prefab;
        private WeaponPanel _activeView;
        private WeaponContainer _container;
        public event Action<WeaponPanel> OnAddView;

        WeaponStoragePresenter(WeaponStorage inventory, WeaponContainer container, WeaponPanel prefab)
        {
            _inventory = inventory;
            _container = container;
            _prefab = prefab;
            _inventory.OnAddWeapon += AddViewContent;
        }

        private void AddViewContent(Weapon weapon)
        {
            var view = GameObject.Instantiate(_prefab, _container.transform.position, Quaternion.identity, _container.Content.transform);
            Debug.Log(view.name);
            view.ItemIcon.sprite = weapon.Icon;
            _view.Add(weapon.WeaponConfig.UseKey, view);
            ChangeActiveView(weapon.WeaponConfig.UseKey);
            OnAddView?.Invoke(GetActiveView());
        }

        public WeaponPanel GetActiveView() => _activeView;

        public WeaponPanel GetView(KeyCode key) => _view[key];
        public void ChangeActiveView(KeyCode key) => _activeView = _view[key];

        public void Dispose()
        {
            _inventory.OnAddWeapon -= AddViewContent;
        }
    }
}
