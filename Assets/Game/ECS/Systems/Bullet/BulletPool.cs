using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Bullet;
using OtusProject.Component.Events;
using OtusProject.Component.Request;

namespace OtusProject.System.Bullet
{
    internal sealed class BulletPool : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<BulletAddPoolRequest, BulletTransform>> _filter;
        private readonly EcsFilterInject<Inc<BulletInActivePool>> _pool;
        private readonly EcsPoolInject<InactiveTag> _intactiveTag;
        private readonly EcsPoolInject<BulletAddPoolRequest> _poolRequest;

        public void Run(IEcsSystems systems)
        {
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