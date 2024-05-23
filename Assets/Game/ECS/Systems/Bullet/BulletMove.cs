using OtusProject.Component.Bullet;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;
using OtusProject.Component.Zombie;

namespace OtusProject.System.Bullet
{
    internal sealed class BulletMove : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<BulletSpeed, BulletLife, BulletPosition, BulletMoveDirection>> _filter;
        public void Run (IEcsSystems systems) 
        {
            var currTime = Time.deltaTime;
            
            foreach (var entity in _filter.Value) 
            {
                //Debug.Log(currTime);
                if (currTime <= _filter.Pools.Inc2.Get(entity).Value)
                {
                    ref var position = ref _filter.Pools.Inc3.Get(entity);
                    ref var moveDirection = ref _filter.Pools.Inc4.Get(entity);
                    ref var moveSpeed = ref _filter.Pools.Inc1.Get(entity);
                    position.Value += moveDirection.Value * (moveSpeed.Value * currTime);
                }
                else
                {
                    currTime = 0;
                }
            }
        }
    }
}