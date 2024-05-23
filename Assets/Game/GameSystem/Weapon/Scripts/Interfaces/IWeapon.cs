using UnityEngine;

namespace OtusProject.Weapons
{
    public interface IWeapon
    {
        public void Attack();
        public void ChangeWeapon(KeyCode code);
    }
}