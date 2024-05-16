using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Request;
using OtusProject.Component.Weapon;
using UnityEngine;

namespace OtusProject.System.Weapon
{ 
    sealed class StartPlayerAttack : IEcsRunSystem 
    {
        private readonly EcsFilterInject<Inc<FireRate, CurrentFireRate, CurrentAmmo, GetCharacter>> _filter;
        private EcsPoolInject<PlayerAttackRequest> _attackRequest;

        public void Run (IEcsSystems systems) 
        {
            var timer = Time.deltaTime;
            foreach (var entity in _filter.Value)
            {
                var getCharacter = _filter.Pools.Inc4.Get(entity).Value;
                var fireRate = _filter.Pools.Inc1.Get(entity).Value;
                var currentAmmo = _filter.Pools.Inc3.Get(entity).Value;
                _filter.Pools.Inc2.Get(entity).Value += timer;
                var currFireRate = _filter.Pools.Inc2.Get(entity).Value;

                if (getCharacter.CurrentWeapon.FireRequired && fireRate <= currFireRate && currentAmmo > 0)
               {
                    _attackRequest.Value.Add(entity);
                    getCharacter.CurrentWeapon.FireRequired = false;
                    _filter.Pools.Inc2.Get(entity).Value = 0;
               }
            }
        }
    }
}