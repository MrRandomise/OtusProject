using UnityEngine;

namespace OtusProject.Config.Weapon
{
    public sealed class Weapon : MonoBehaviour
    {
        public WeaponConfig WeaponConfig;
        public BulletConfig BulletConfig;
        public bool FireRequired = false;
        public Transform BulletPoint;
    }
}
