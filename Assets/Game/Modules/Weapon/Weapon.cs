using UnityEngine;

namespace OtusProject.Weapons
{
    public sealed class Weapon : MonoBehaviour
    {
        public WeaponConfig WeaponConfig;
        public BulletConfig BulletConfig;
        public Transform Point;
        public Transform WeaponContainer;
        public Sprite Icon;
    }
}
