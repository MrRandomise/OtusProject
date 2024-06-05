using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component;
using OtusProject.Component.Zombie;
using OtusProject.Component.Events;
using UnityEngine;

namespace OtusProject.System.Zombie
{
    internal sealed class ZombieControl : IEcsRunSystem 
    {
        private readonly EcsFilterInject<Inc<AttackDistance, CurrentTransform, ZombieTarget>, Exc<InactiveTag, DeadTag, DeathEvent>> _filter;
        private readonly EcsPoolInject<AttackEvent> _attackEvent;

        public void Run (IEcsSystems systems) 
        {
            foreach(var entity in _filter.Value)
            {
                var targetPos = _filter.Pools.Inc3.Get(entity);
                var zombiePos = _filter.Pools.Inc2.Get(entity);
                var attackDist = _filter.Pools.Inc1.Get(entity).Value;
                var dist = Vector3.Distance(targetPos.Value.position, zombiePos.Value.position);
                if (dist <= attackDist)
                {
                    _attackEvent.Value.Add(entity);
                }
            }
        }
    }
}