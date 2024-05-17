using UnityEngine;

namespace OtusProject.Config.Weapon
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "Config/Weapon")]
    public sealed class WeaponConfig : ScriptableObject
    {
        public ScriptableObject BulletWeapon;
        public GameObject Bullet;
        public int MaxAmmo;
        public int CurrAmmo;
        public float FireRate;
        public float ReloadTime;
    }
}
