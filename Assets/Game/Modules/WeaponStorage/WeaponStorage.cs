using System.Collections.Generic;
using OtusProject.Weapons;
using System;
using UnityEngine;

namespace OtusProject.Inventary
{
    public sealed class WeaponStorage : IWeaponStorage
    {
        private Dictionary<KeyCode, Weapon> _weapon = new Dictionary<KeyCode, Weapon>();
        public event Action<Weapon> OnAddWeapon;
        public event Action OnRemoveWeapon;
        public event Action<Weapon, KeyCode> OnChangeActive;
        private Weapon ActiveWeapon = null;

        public void AddWeapon(Weapon weapon, KeyCode key)
        {
            var item = GameObject.Instantiate(weapon, weapon.WeaponContainer.position, weapon.WeaponContainer.rotation, weapon.WeaponContainer);
            _weapon.Add(key, item);
            ActiveWeapon = item;
            OnAddWeapon?.Invoke(weapon);
            ChangeActiveWeapon(key);
        }

        public void ChangeActiveWeapon(KeyCode key)
        {
            ActiveWeapon = _weapon[key];
            OnChangeActive?.Invoke(ActiveWeapon, key);
        }

        public void RemoveWeapon(KeyCode key)
        {
            _weapon.Remove(key);
            OnRemoveWeapon?.Invoke();
        }

        public Weapon GetActiveWeapon() => ActiveWeapon;

        public bool TryGetWeapon(KeyCode key, out Weapon data)
        {
            try
            {
                if (_weapon[key] != null)
                {
                    data = _weapon[key];
                    return true;
                }
            }
            catch (Exception e)
            {
                //empty
            }
            data = null;
            return false;
        }
    }
}
