using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Zombie;
using OtusProject.Component.Events;
using OtusProject.Component.Bullet;

namespace OtusProject.System.Zombie
{
    internal sealed class ZombieMoviement : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<ZombieNavAgent, ZombieTarget, ZombiePosition>, Exc<DeadTag, InactiveTag>> _filter;
        private readonly EcsPoolInject<DeathEvent> _deathEvent;
        private readonly EcsPoolInject<MoveEvent> _moveEvent;
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var agent = _filter.Pools.Inc1.Get(entity);
                ref var position = ref _filter.Pools.Inc3.Get(entity);
                if (_moveEvent.Value.Has(entity) && !_deathEvent.Value.Has(entity))
                {
                    var target = _filter.Pools.Inc2.Get(entity).Value;
                    agent.Value.destination = target.position;
                    position.Value = agent.Value.transform.position;
                }
                else if (_deathEvent.Value.Has(entity))
                {
                    agent.Value.destination = position.Value;
                }
            }
        }
    }
}