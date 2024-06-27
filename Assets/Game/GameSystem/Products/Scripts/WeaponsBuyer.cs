using OtusProject.Weapons;
using System;
using UnityEngine;
using OtusProject.Inventary;
namespace OtusProject.ItemSystem
{
    [Serializable]
    public sealed class WeaponsBuyer : IProduct
    {
        [SerializeField] private Weapon weapon;
        private static WeaponStorage _inventory;

        WeaponsBuyer(WeaponStorage inventory)
        {
            _inventory = inventory;
        }
        public void BuyProduct()
        {
            _inventory.AddWeapon(weapon, weapon.WeaponConfig.UseKey);
        }
      
    }
}

