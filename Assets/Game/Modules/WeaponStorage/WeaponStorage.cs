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
        public event Action<Weapon> OnChangeActive;
        private Weapon ActiveWeapon = null;

        public void AddWeapon(Weapon weapon, KeyCode key)
        {
            var item = GameObject.Instantiate(weapon, weapon.WeaponContainer.position, weapon.WeaponContainer.rotation);
            item.transform.SetParent(weapon.WeaponContainer);
            _weapon.Add(key, item);
            OnAddWeapon?.Invoke(weapon);
        }

        public void ChangeActiveWeapon(KeyCode key)
        {
            OnChangeActive?.Invoke(_weapon[key]);
            ActiveWeapon = _weapon[key];
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
