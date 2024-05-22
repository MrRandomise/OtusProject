using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Bullet;
using OtusProject.Component.Zombie;
using UnityEngine;
using OtusProject.Component.Spawn;
using OtusProject.Component.Request;

namespace OtusProject.System.Pools
{
    sealed class ZombiesPools : IEcsRunSystem 
    {
        private readonly EcsFilterInject<Inc<ZombieAddPoolRequest, ZombieDeathTimeout, ZombieTransform>> _filter;
        private readonly EcsFilterInject<Inc<SpawnInActivePool>> _pool;
        private readonly EcsPoolInject<ZombieAddPoolRequest> _poolRequest;
        private readonly EcsPoolInject<InactiveTag> _inactiveTag;
        private float _currTimer = 0;
        public void Run (IEcsSystems systems) 
        {
            _currTimer += Time.deltaTime;
            foreach (var entity in _filter.Value) 
            {
                var timer = _filter.Pools.Inc2.Get(entity);
                ref var zombieTransform = ref _filter.Pools.Inc3.Get(entity).Value;
                foreach (var pool in _pool.Value)
                {
                    var inActivePool = _pool.Pools.Inc1.Get(pool);
                    if (_currTimer >= timer.Value)
                    {
                        zombieTransform.SetParent(inActivePool.Value);
                        _inactiveTag.Value.Add(entity);
                        _currTimer = 0;
                        _poolRequest.Value.Del(entity);
                    }
                }
            }
            
        }
    }
}