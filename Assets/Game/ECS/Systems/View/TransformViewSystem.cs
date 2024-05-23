using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Bullet;

namespace EcsEngine.Systems.View
{
    internal sealed class TransformViewSystem : IEcsPostRunSystem
    {
        private readonly EcsFilterInject<Inc<BulletTransform, BulletPosition>> _filter;
        public void PostRun(IEcsSystems systems)
        {
           
            foreach (var entity in _filter.Value)
            {
                ref var transform = ref _filter.Pools.Inc1.Get(entity);
                var position = _filter.Pools.Inc2.Get(entity);
                transform.Value.position = position.Value;
            }
        }
    }
}