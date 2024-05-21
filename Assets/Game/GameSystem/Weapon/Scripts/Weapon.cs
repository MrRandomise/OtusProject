using UnityEngine;

namespace OtusProject.Config.Weapons
{
    public sealed class Weapon : MonoBehaviour
    {
        public WeaponConfig WeaponConfig;
        public BulletConfig BulletConfig;
        public Transform BulletPoint;
    }
}
