using System;

namespace OtusProject.Weapons
{
    interface IRangeWeapon
    {
        event Action OnReload;
        void Reload();
    }
}