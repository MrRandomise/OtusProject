using OtusProject.View;
using System;
using UnityEngine;

namespace OtusProject.Weapons
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "Config/Weapon")]
    public sealed class WeaponConfig : ScriptableObject
    {
        public WeaponPanel WeaponView;
        public int MaxAmmo;
        public int CurrAmmo;
        public float FireRate;
        public float ReloadTime;
        public KeyCode UseKey;

        private void OnDisable()
        {
            CurrAmmo = MaxAmmo;
        }
    }
}

