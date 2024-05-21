using UnityEngine;
using OtusProject.Items;

namespace OtusProject.Config.Weapon
{
    public sealed class Weapon : MonoBehaviour, IItems
    {
        public WeaponConfig WeaponConfig;
        public BulletConfig BulletConfig;
        public Transform BulletPoint;

        public void UseItem()
        {
            WeaponConfig.CurrAmmo = WeaponConfig.MaxAmmo;
        }
    }
}
