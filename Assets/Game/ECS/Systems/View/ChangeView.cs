using Leopotam.EcsLite.Di;
using Leopotam.EcsLite;
using OtusProject.Component.Request;
using OtusProject.Component.Spawn;
using OtusProject.Component.Events;

namespace OtusProject.Systems.View
{
    internal sealed class ChangeView : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<ChangeViewEvent>> _filter;
        private readonly EcsFilterInject<Inc<ZombieViewComponent>> _view;
        private int _kills = 0;
        public void Run(IEcsSystems systems)
        {
            var view = _view.Pools.Inc1;
            foreach (var entity in _filter.Value)
            {
                _kills++;
                foreach(var entity2 in _view.Value)
                {
                    view.Get(entity2).Value.Kills.text = $"x {_kills}";
                }
            }
        }
    }
}