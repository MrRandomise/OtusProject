using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;
using OtusProject.Component;

namespace OtusProject.System.Bullet
{
    internal sealed class BulletMove : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<Speed, CurrentTransform, MoveDirection, BulletTag>> _filter;
        public void Run (IEcsSystems systems) 
        {
            foreach (var entity in _filter.Value) 
            {
                ref var position = ref _filter.Pools.Inc2.Get(entity);
                ref var moveDirection = ref _filter.Pools.Inc3.Get(entity);
                ref var moveSpeed = ref _filter.Pools.Inc1.Get(entity);
                position.Value.position += moveDirection.Value * moveSpeed.Value * Time.deltaTime;
            }
        }
    }
}