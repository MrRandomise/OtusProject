using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Events;
using OtusProject.Component;
using UnityEngine;

namespace OtusProject.System.Zombie
{
    internal sealed class TakeBulletEffectsSystem : IEcsRunSystem 
    {
        
        private readonly EcsFilterInject<Inc<HitEvent, CurrentHealth, ZombieTag>> _filter;
        public void Run (IEcsSystems systems) {
            var damage = _filter.Pools.Inc1;
            foreach (var entity in _filter.Value)
            {
                damage.Get(entity).Effect.UseEffect(damage.Get(entity).target);
            }
        }
    }
}