using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component;
using OtusProject.Component.Request;
using OtusProject.ECSEvent;

namespace OtusProject.System.Zombie
{
    internal sealed class DropSystem : IEcsRunSystem 
    {
        private readonly EcsFilterInject<Inc<Drops, CurrentTransform, ZombieTag>> _filter;
        private readonly EcsPoolInject<DropRequest> _dropRequest;
        private EcsCustomInject<OnDeathInECS> _onDeath;
        public void Run (IEcsSystems systems) {
            var pref = _filter.Pools.Inc1;
            var pos = _filter.Pools.Inc2;
            foreach (var entity in _filter.Value)
            {
                if(_dropRequest.Value.Has(entity))
                {
                    _onDeath.Value.OnDeathEvent(_filter.Pools.Inc1.Get(entity).Value, _filter.Pools.Inc2.Get(entity).Value);
                    _dropRequest.Value.Del(entity);
                }
            }
        }
    }
}