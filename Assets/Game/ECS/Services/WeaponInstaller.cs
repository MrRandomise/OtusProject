using Leopotam.EcsLite.Entities;
using OtusProject.Component.Weapon;
using OtusProject.Player;
using UnityEngine;

namespace OtusProject.Content
{
    public sealed class WeaponInstaller : EntityInstaller
    {
        [SerializeField] private Character _character;
        private float _fireRate;
        private float _reloadTime;
        private int _maxAmmo;

        private void Start()
        {
            _fireRate = _character.CurrentWeapon.WeaponConfig.FireRate;
            _reloadTime = _character.CurrentWeapon.WeaponConfig.ReloadTime;
            _maxAmmo = _character.CurrentWeapon.WeaponConfig.MaxAmmo;
        }

        protected override void Install(Entity entity)
        {
            entity.AddData(new FireRate { Value = _fireRate });
            entity.AddData(new CurrentFireRate { Value = _fireRate });
            entity.AddData(new MaxAmmo { Value = _maxAmmo });
            entity.AddData(new CurrentAmmo { Value = _maxAmmo });
            entity.AddData(new ReloadTime { Value = _reloadTime });
            entity.AddData(new GetCharacter { Value = _character });
        }

        protected override void Dispose(Entity entity)
        {

        }
    }
}
