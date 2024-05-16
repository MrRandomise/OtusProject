using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Request;
using OtusProject.Component.Weapon;
using UnityEngine;

namespace OtusProject.System.Weapon
{
    sealed class PlayerAtack : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<CurrentAmmo>> _filter;
        private EcsPoolInject<PlayerAttackRequest> _attackRequest;
        public void Run (IEcsSystems systems) 
        {
            foreach(var entity in _filter.Value) 
            {
                if(_attackRequest.Value.Has(entity))
                {
                    _filter.Pools.Inc1.Get(entity).Value -= 1;
                    Debug.Log($"Выстрел, осталось патронов {_filter.Pools.Inc1.Get(entity).Value}");
                    _attackRequest.Value.Del(entity);
                }
            }    
        }
    }
}