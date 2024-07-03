using UnityEngine;

namespace OtusProject.Weapons
{
    public sealed class Weapon : MonoBehaviour
    {
        public WeaponConfig WeaponConfig;
        public GameObject Bullet;
        public Transform Point;
        public Transform WeaponContainer;
        public Sprite Icon;
    }
}
