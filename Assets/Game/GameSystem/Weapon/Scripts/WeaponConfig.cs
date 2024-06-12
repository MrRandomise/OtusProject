using OtusProject.ItemSystem;
using OtusProject.View;
using UnityEngine;

namespace OtusProject.Weapons
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "Config/Weapon")]
    public sealed class WeaponConfig : ScriptableObject
    {
        [HideInInspector] public WeaponPanel WeaponContent;
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

