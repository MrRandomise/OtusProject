using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component;
using UnityEngine;

namespace OtusProject.System.Zombie
{
    internal sealed class NavMashSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<NavAgent, Target, CurrentTransform, MoveDirection, ZombieTag>, Exc<InactiveTag>> _filter;
        private readonly EcsPoolInject<DeadTag> _inactiveTag;
        public void Run(IEcsSystems systems)
        {

            foreach (var entity in _filter.Value)
            {
                var agent = _filter.Pools.Inc1.Get(entity);
                ref var moveDirection = ref _filter.Pools.Inc4.Get(entity);
                ref var position = ref _filter.Pools.Inc3.Get(entity);
                var target = _filter.Pools.Inc2.Get(entity).Value;

                if(_inactiveTag.Value.Has(entity))
                {
                    agent.Value.destination = position.Value.position;
                    moveDirection.Value = Vector3.zero;
                }
                else
                {
                    agent.Value.destination = target.position;
                    position.Value = agent.Value.transform;
                    moveDirection.Value = position.Value.position;
                }
            }
        }
    }
}