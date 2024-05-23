using Leopotam.EcsLite.Di;
using Leopotam.EcsLite;
using OtusProject.Component.Spawn;
using OtusProject.Component.Events;

namespace OtusProject.Systems.View
{
    internal sealed class ChangeView : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<ChangeViewEvent>> _filter;
        private readonly EcsFilterInject<Inc<ZombieViewComponent, WaveViewComponent>> _view;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
               
                foreach (var entity2 in _view.Value)
                {
                    if (_filter.Pools.Inc1.Get(entity).ViewValue == 1)
                    {
                        _view.Pools.Inc1.Get(entity2).Value.Kills.text = $"x {_filter.Pools.Inc1.Get(entity).Value}";
                    }
                    else
                    {
                        _view.Pools.Inc2.Get(entity2).Value.Waves.text = $"x {_filter.Pools.Inc1.Get(entity).Value}";
                    }
                }
            }
        }
    }
}