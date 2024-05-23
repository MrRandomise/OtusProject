using OtusProject.ItemSystem;
using OtusProject.Weapons;
using UnityEngine;

namespace OtusProject.Config.Weapons
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "Config/Weapon")]
    public sealed class WeaponConfig : ScriptableObject
    {
        [SerializeReference] public IWeapon WeaponItem;
        public int MaxAmmo;
        public int CurrAmmo;
        public float FireRate;
        public float ReloadTime;
        public string UseKey;
    }
}

