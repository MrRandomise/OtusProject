using OtusProject.Weapons;
using System;
using UnityEngine;
using Zenject;
using OtusProject.Inventary;
namespace OtusProject.ItemSystem
{
    [Serializable]
    public sealed class WeaponsBuyer : IProduct
    {
        [SerializeField] private Weapon weapon;
        private static WeaponInventory _inventory;

        [Inject]
        private void Construct(WeaponInventory inventory)
        {
            _inventory = inventory;
        }
        public void BuyProduct()
        {
            _inventory.AddWeapon(weapon);
        }
      
    }
}

