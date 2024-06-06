using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Zombie;
using OtusProject.Component.Events;
using OtusProject.Component;
using UnityEngine;

namespace OtusProject.System.Zombie
{
    internal sealed class ZombieMoviement : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<ZombieNavAgent, ZombieTarget, CurrentTransform>, Exc<InactiveTag, MoveEvent>> _filter;
        private readonly EcsPoolInject<MoveEvent> _moveEvent;
        private readonly EcsPoolInject<DeadTag> _inactiveTag;
        public void Run(IEcsSystems systems)
        {

            foreach (var entity in _filter.Value)
            {
                
                _moveEvent.Value.Add(entity);
                var agent = _filter.Pools.Inc1.Get(entity);
                ref var position = ref _filter.Pools.Inc3.Get(entity);
                var target = _filter.Pools.Inc2.Get(entity).Value;
                
                if(!_inactiveTag.Value.Has(entity))
                {
                    agent.Value.destination = target.position;
                    position.Value = agent.Value.transform;
                }
                else
                {
                    agent.Value.destination = position.Value.position;
                }
            }
        }
    }
}