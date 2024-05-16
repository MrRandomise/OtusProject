using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Request;
using OtusProject.Component.Zombie;

namespace OtusProject.System.Zombie
{
    sealed class ZombieMoviement : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<ZombieNavAgent, ZombieTarget>> _filter;
        private readonly EcsPoolInject<ZombieMoveRequest> _zombieMoveRequest;
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                if(_zombieMoveRequest.Value.Has(entity))
                {
                    var agent = _filter.Pools.Inc1.Get(entity).Value;
                    var target = _filter.Pools.Inc2.Get(entity).Value;
                    agent.destination = target.position;
                }
            }
        }
    }
}