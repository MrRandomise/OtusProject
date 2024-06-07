using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component;
using OtusProject.Component.Request;
using UnityEngine;

namespace OtusProject.System.Zombie
{
    sealed class DamageSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<DamageRequest, CurrentHealth, ZombieTag>> _filter;
        private readonly EcsPoolInject<DamageRequest> _damageRequest;
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                ref var health = ref  _filter.Pools.Inc2.Get(entity).Value;
                var damage = _filter.Pools.Inc1.Get(entity).Value;
                health -= damage;
                _damageRequest.Value.Del(entity);
            }
        }
    }
}