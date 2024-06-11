using OtusProject.ItemSystem;
using OtusProject.View;
using OtusProject.Weapons;
using System;
using UnityEngine;

namespace OtusProject.Config.Weapons
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "Config/Weapon")]
    public sealed class WeaponConfig : ScriptableObject
    {
        public int MaxAmmo;
        public int CurrAmmo;
        public float FireRate;
        public float ReloadTime;
        public KeyCode UseKey;
        [NonSerialized] public WeaponPanel View;

        private void OnDisable()
        {
            CurrAmmo = MaxAmmo;
        }
    }
}

