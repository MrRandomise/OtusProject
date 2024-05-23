using System;

namespace OtusProject.Weapons
{
    interface IWeapon
    {
        event Action OnAttack;
        event Action OnChangeWeapon;

        void Attack();
        void ChangeWeapon();
    }
}