using UnityEngine;

namespace OtusProject.Config.Weapon
{
    public sealed class Weapon : MonoBehaviour
    {
        public WeaponConfig WeaponConfig;
        public BulletConfig BulletConfig;
        public Transform BulletPoint;
        public Transform BullePool;

        private void Start ()
        {
            WeaponConfig.CurrAmmo = WeaponConfig.MaxAmmo;
        }
    }
}
