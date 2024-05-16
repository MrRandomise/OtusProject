using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Events;
using OtusProject.Component.Pool;
using OtusProject.Component.Request;
using OtusProject.Component.Zombie;
using UnityEngine; 

namespace Client {
    sealed class ZombieControl : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<ZombieAttackDistance, ZombieNavAgent, Position, ZombieTarget>> _filter;
        private readonly EcsPoolInject<ZombieMoveRequest> _moveRequest;
        private readonly EcsPoolInject<ZombieAttackRequest> _moveAttack;

        public void Run (IEcsSystems systems) 
        {
            foreach(var entity in _filter.Value)
            {
                var agent = _filter.Pools.Inc2.Get(entity).Value;
                var attackDist = _filter.Pools.Inc1.Get(entity).Value;
                var dist = Vector3.Distance(_filter.Pools.Inc4.Get(entity).Value.position, _filter.Pools.Inc3.Get(entity).Value.position);
                if (agent.remainingDistance == 0)
                {
                    _moveRequest.Value.Add(entity);
                }
                else if (dist <= attackDist)
                {
                    _moveAttack.Value.Add(entity);
                }
                else
                {
                    _moveRequest.Value.Add(entity);
                }
            }
        }
    }
}