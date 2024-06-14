using OtusProject.Inventary;
using UnityEngine;
using Zenject;

namespace OtusProject.Weapons
{
    public sealed class AddWeapon : MonoBehaviour
    {
        [SerializeField] private Weapon _weaponConfig;
        private WeaponInventory _weaponInventory;

        [Inject]
        private void Construct(WeaponInventory weaponInventory)
        {
            _weaponInventory = weaponInventory;
        }

        private void Awake()
        {
            _weaponInventory.AddWeapon(_weaponConfig);
        }
    }
}

