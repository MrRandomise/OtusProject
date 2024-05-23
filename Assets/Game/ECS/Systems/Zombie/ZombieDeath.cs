using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Bullet;
using OtusProject.Component.Events;
using OtusProject.Component.Zombie;
using OtusProject.Component.Request;
using OtusProject.Component.Spawn;
using TMPro;

namespace OtusProject.System.Zombie
{
    internal sealed class ZombieDeath : IEcsRunSystem 
    {        
        private readonly EcsFilterInject<Inc<ZombieCurrHealth>, Exc<InactiveTag, DeadTag>> _filter;
        private readonly EcsPoolInject<DeathEvent> _deadEvent;
        private readonly EcsPoolInject<DeadTag> _deadTag;
        private readonly EcsPoolInject<MoveEvent> _moveEvent;
        private readonly EcsPoolInject<ZombieDeathRequest> _dethRequest;
        private readonly EcsPoolInject<ZombieDropRequest> _dropRequest;
        private readonly EcsPoolInject<ZombieAddPoolRequest> _poolRequest;
        private readonly EcsPoolInject<ChangeViewEvent> _changeView;
        private readonly int _viewComponent = 1;
        private int _kills = 0;
        public void Run (IEcsSystems systems) 
        {
            foreach (var entity in _filter.Value)
            {
                if (_filter.Pools.Inc1.Get(entity).Value <= 0)
                {
                    _kills++;
                    if (!_changeView.Value.Has(entity))
                    {
                        _changeView.Value.Add(entity).Value = _kills;
                    }
                    else
                    {
                        _changeView.Value.Get(entity).Value = _kills;
                    }
                    _changeView.Value.Get(entity).ViewValue = _viewComponent;
                    _deadTag.Value.Add(entity);
                    _deadEvent.Value.Add(entity);
                    _dethRequest.Value.Add(entity);
                    _dropRequest.Value.Add(entity);
                    _poolRequest.Value.Add(entity);
                    _moveEvent.Value.Del(entity);
                }
            }
        }
    }
}