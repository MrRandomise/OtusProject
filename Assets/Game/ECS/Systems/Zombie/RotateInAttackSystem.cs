using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Events;
using OtusProject.Component;
using UnityEngine;
using OtusProject.Component.Zombie;
namespace OtusProject.System.Zombie
{
    sealed class RotateInAttackSystem : IEcsRunSystem 
    {
        private readonly EcsFilterInject<Inc<RotateSpeed, CurrentTransform, AttackEvent, ZombieTarget>> _filter;
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