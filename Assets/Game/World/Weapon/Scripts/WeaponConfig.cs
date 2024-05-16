using UnityEngine;

namespace OtusProject.Config.Weapon
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "Config/Weapon")]
    public sealed class WeaponConfig : ScriptableObject
    {
        public ScriptableObject BulletWeapon;
        public int MaxAmmo;
        public float FireRate;
        public float ReloadTime;
    }
}

