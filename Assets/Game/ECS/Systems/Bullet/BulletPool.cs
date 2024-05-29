using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Bullet;
using OtusProject.Component.Request;
using UnityEngine;

namespace OtusProject.System.Bullet
{
    internal sealed class BulletPool : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<BulletAddPoolRequest, BulletTransform>, Exc<BulletInactiveTag>> _filter;
        private readonly EcsFilterInject<Inc<BulletInActivePool>> _pool;
        private readonly EcsFilterInject<Inc<BulletLife, BulletTransform, CurrBulletLife>, Exc<BulletInactiveTag>> _poolTimer;
        private readonly EcsPoolInject<BulletInactiveTag> _intactiveTag;
        private readonly EcsPoolInject<BulletAddPoolRequest> _poolRequest;
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _poolTimer.Value)
            {
                var lifeTimer = _poolTimer.Pools.Inc1.Get(entity);
                var zombieTransform = _poolTimer.Pools.Inc2.Get(entity).Value;
                ref var currBulletLife = ref _poolTimer.Pools.Inc3.Get(entity).Value;
                currBulletLife += Time.deltaTime;
                foreach (var pool in _pool.Value)
                {
                    var inActivePool = _pool.Pools.Inc1.Get(pool);
                    if (currBulletLife >= lifeTimer.Value)
                    {
                        zombieTransform.SetParent(inActivePool.Value);
                        _intactiveTag.Value.Add(entity);
                        currBulletLife = 0;
                    }
                }
            }

            foreach (var entity in _filter.Value)
            {
                ref var trans = ref _filter.Pools.Inc2.Get(entity);
                foreach (var pool in _pool.Value)
                {
                    var inActivepool = _pool.Pools.Inc1.Get(pool);
                    _poolRequest.Value.Del(entity);
                    _intactiveTag.Value.Add(entity);
                    trans.Value.SetParent(inActivepool.Value);
                }
            }
        }
    }
}