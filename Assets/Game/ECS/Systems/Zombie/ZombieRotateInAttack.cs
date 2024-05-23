using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Events;
using OtusProject.Component.Zombie;
using UnityEngine;
namespace OtusProject.System.Zombie
{
    sealed class ZombieRotateInAttack : IEcsRunSystem 
    {
        private readonly EcsFilterInject<Inc<ZombieRotateSpeed, ZombieTransform, AttackEvent, ZombieTarget>> _filter;
        private readonly EcsPoolInject<AttackEvent> _attackEvent;
        public void Run (IEcsSystems systems) 
        {
            foreach(var entity in _filter.Value)
            {
                ref var transform = ref _filter.Pools.Inc2.Get(entity);
                var lookTarget = _filter.Pools.Inc4.Get(entity).Value.transform.position;
                transform.Value.LookAt(new Vector3(lookTarget.x, transform.Value.position.y, lookTarget.z));
            }
        }
    }
}