using OtusProject.Weapons;
using UnityEngine;

namespace OtusProject.Inventary
{
    public interface IWeaponInventory
    {
        bool TryGetWeapon(KeyCode weapon, out Weapon data);
        void AddWeapon(Weapon weapon);
        void RemoveWeapon(KeyCode weapon);
        Weapon GetActiveWeapon();
        void ChangeActiveWeapon(KeyCode weapon);
    }
}

