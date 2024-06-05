using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Events;
using OtusProject.Component.Request;
using OtusProject.Component;

namespace OtusProject.System.Zombie
{
    internal sealed class DeathSystem : IEcsRunSystem 
    {        
        private readonly EcsFilterInject<Inc<CurrentHealth>, Exc<InactiveTag, DeadTag>> _filter;
        private readonly EcsPoolInject<DeathEvent> _deadEvent;
        private readonly EcsPoolInject<DeadTag> _deadTag;
        private readonly EcsPoolInject<MoveEvent> _moveEvent;
        private readonly EcsPoolInject<DeathRequest> _dethRequest;
        private readonly EcsPoolInject<DropRequest> _dropRequest;
        public void Run (IEcsSystems systems) 
        {
            foreach (var entity in _filter.Value)
            {
                if (_filter.Pools.Inc1.Get(entity).Value <= 0)
                {
                    //if (!_changeView.Value.Has(entity))
                    //{
                    //    _changeView.Value.Add(entity).Value = _kills;
                    //}
                    //else
                    //{
                    //    _changeView.Value.Get(entity).Value = _kills;
                    //}
                    _deadTag.Value.Add(entity);
                    _deadEvent.Value.Add(entity);
                    _dethRequest.Value.Add(entity);
                    _dropRequest.Value.Add(entity);
                    _moveEvent.Value.Del(entity);
                }
            }
        }
    }
}