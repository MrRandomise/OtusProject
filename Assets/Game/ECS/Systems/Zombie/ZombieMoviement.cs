using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Events;
using OtusProject.Component.Pool;
using OtusProject.Component.Zombie;

namespace OtusProject.MoviementSystem
{
    sealed class ZombieMoviement : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<ZombieNavAgent, ZombieAttackDistance, Position, ZombieTarget>> _filter;
        private readonly EcsPoolInject<ZombieMoveEvent> _zombieMoveEvent;
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var agent = _filter.Pools.Inc1.Get(entity).Value;
                var target = _filter.Pools.Inc4.Get(entity).Value;
                var moveDirection = (_filter.Pools.Inc3.Get(entity).Value - target.transform.position).normalized;
                agent.destination = target.position;
                _zombieMoveEvent.Value.Add(entity);
            }
        }
    }
}