using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Events;
using OtusProject.Component.Zombie;
using UnityEngine;

namespace OtusProject.System.Zombie
{
    internal sealed class ZombieTakeDamage : IEcsRunSystem 
    {
        
        private readonly EcsFilterInject<Inc<DamageRequest>> _filter;
        private readonly EcsPoolInject<ZombieHealth> _health;
        private readonly EcsPoolInject<DamageRequest> _damage;
        public void Run (IEcsSystems systems) {
            var damage = _filter.Pools.Inc1;
            foreach (var entity in _filter.Value)
            {
                if (_health.Value.Has(entity))
                {
                    _health.Value.Get(entity).Value -= damage.Get(entity).Value;
                    _damage.Value.Del(entity);
                }
            }
        }
    }
}