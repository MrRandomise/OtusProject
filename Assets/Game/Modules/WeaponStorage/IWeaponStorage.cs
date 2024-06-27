using OtusProject.Weapons;
using UnityEngine;

namespace OtusProject.Inventary
{
    public interface IWeaponStorage
    {
        bool TryGetWeapon(KeyCode weapon, out Weapon data);
        void AddWeapon(Weapon weapon, KeyCode key);
        void RemoveWeapon(KeyCode weapon);
        public Weapon GetActiveWeapon();
        public void ChangeActiveWeapon(KeyCode key);
    }
}

