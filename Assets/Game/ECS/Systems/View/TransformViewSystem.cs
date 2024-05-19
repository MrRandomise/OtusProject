using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.View;
using OtusProject.Component.Zombie;

namespace EcsEngine.Systems.View
{
    internal sealed class TransformViewSystem : IEcsPostRunSystem
    {
        private readonly EcsFilterInject<Inc<TransformView, BulletPosition>> _filter;
        public void PostRun(IEcsSystems systems)
        {
           
            foreach (var entity in _filter.Value)
            {
                ref TransformView transform = ref _filter.Pools.Inc1.Get(entity);
                var position = _filter.Pools.Inc2.Get(entity);
                transform.Value.position = position.Value;
            }
        }
    }
}