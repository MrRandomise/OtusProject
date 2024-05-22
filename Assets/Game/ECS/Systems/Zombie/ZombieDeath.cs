using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Bullet;
using OtusProject.Component.Events;
using OtusProject.Component.Zombie;
using OtusProject.Component.Request;

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
        public void Run (IEcsSystems systems) 
        {
            foreach (var entity in _filter.Value)
            {
                if(_filter.Pools.Inc1.Get(entity).Value <= 0)
                {
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