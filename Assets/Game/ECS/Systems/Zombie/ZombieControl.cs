using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Bullet;
using OtusProject.Component.Zombie;
using OtusProject.Component.Events;
using UnityEngine;

namespace OtusProject.System.Zombie
{
    internal sealed class ZombieControl : IEcsRunSystem 
    {
        private readonly EcsFilterInject<Inc<ZombieAttackDistance, ZombiePosition, ZombieTarget>, Exc<DeadTag>> _filter;
        private readonly EcsPoolInject<MoveEvent> _moveEvent;
        private readonly EcsPoolInject<AttackEvent> _attackEvent;
        private readonly EcsPoolInject<DeathEvent> _deadEvent;

        public void Run (IEcsSystems systems) 
        {
            foreach(var entity in _filter.Value)
            {
                var attackDist = _filter.Pools.Inc1.Get(entity).Value;
                var dist = Vector3.Distance(_filter.Pools.Inc3.Get(entity).Value.position, _filter.Pools.Inc2.Get(entity).Value);
                if (!_deadEvent.Value.Has(entity))
                {
                    if (dist <= attackDist)
                    {
                        _attackEvent.Value.Add(entity);
                    }
                    else
                    {
                        _moveEvent.Value.Add(entity);
                    }
                }
            }
        }
    }
}