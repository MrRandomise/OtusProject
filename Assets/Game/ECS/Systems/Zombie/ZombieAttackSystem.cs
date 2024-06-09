using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component;
using OtusProject.Component.Events;
using UnityEngine;

namespace OtusProject.System.Zombie
{
    internal sealed class ZombieAttackSystem : IEcsRunSystem 
    {
        private readonly EcsFilterInject<Inc<AttackDistance, CurrentTransform, Target>, Exc<DeadTag, DeathEvent>> _filter;
        private readonly EcsFilterInject<Inc<CharacterTag>, Exc<DeadTag, DeathEvent>> _targetFilter;
        private readonly EcsPoolInject<AttackEvent> _attackEvent;

        public void Run (IEcsSystems systems) 
        {
            foreach (var targetEntity in _targetFilter.Value) 
            {
                foreach (var entity in _filter.Value)
                {
                    var targetPos = _filter.Pools.Inc3.Get(entity);
                    var zombiePos = _filter.Pools.Inc2.Get(entity);
                    var attackDist = _filter.Pools.Inc1.Get(entity).Value;
                    var dist = Vector3.Distance(targetPos.Value.transform.position, zombiePos.Value.position);
                    if (dist <= attackDist)
                    {
                        _attackEvent.Value.Add(entity);
                    }
                }
            }
        }
    }
}