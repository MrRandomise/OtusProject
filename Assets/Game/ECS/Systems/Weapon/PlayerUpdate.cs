using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Weapon;
using UnityEngine;

namespace OtusProject.System.PlayerUpdate
{ 
    sealed class PlayerUpdate : IEcsRunSystem 
    {      
        private readonly EcsFilterInject<Inc<GetCharacter, FireRate, MaxAmmo, ReloadTime>> _filter;
        public void Run (IEcsSystems systems) 
        {
            foreach(var entity in _filter.Value)
            {
                var getCharacter = _filter.Pools.Inc1.Get(entity).Value;
                _filter.Pools.Inc2.Get(entity).Value = getCharacter.CurrentWeapon.WeaponConfig.FireRate;
                _filter.Pools.Inc3.Get(entity).Value = getCharacter.CurrentWeapon.WeaponConfig.MaxAmmo;
                _filter.Pools.Inc4.Get(entity).Value = getCharacter.CurrentWeapon.WeaponConfig.ReloadTime;
            }
        }
    }
}