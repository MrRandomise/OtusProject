using System.Collections.Generic;
using OtusProject.Weapons;
using System;
using UnityEngine;
using Zenject.ReflectionBaking.Mono.Cecil.Cil;

namespace OtusProject.Inventary
{
    public sealed class WeaponInventory : IWeaponInventory
    {
        private Dictionary<KeyCode, Weapon> _weapon = new Dictionary<KeyCode, Weapon>();
        public event Action<Weapon> OnAddWeapon;
        public event Action OnRemoveWeapon;
        public event Action<Weapon> OnChangeActive;

        private Weapon ActiveWeapon = null;

        public Weapon GetActiveWeapon() => ActiveWeapon;

        public void AddWeapon(Weapon weapon)
        {
            var item = GameObject.Instantiate(weapon, weapon.WeaponContainer.transform.position, weapon.WeaponContainer.transform.rotation, weapon.WeaponContainer.transform);
            _weapon.Add(weapon.WeaponConfig.UseKey, item);
            ActiveWeapon = item;
            OnAddWeapon?.Invoke(item);
        }

        public void RemoveWeapon(KeyCode key)
        {
            _weapon.Remove(key);
            OnRemoveWeapon?.Invoke();
        }
        public void ChangeActiveWeapon(KeyCode key)
        {
            ActiveWeapon = _weapon[key];
            OnChangeActive?.Invoke(_weapon[key]);
        }


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
