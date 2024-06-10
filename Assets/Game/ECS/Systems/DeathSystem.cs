using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Events;
using OtusProject.Component.Request;
using OtusProject.Component;
using OtusProject.ECSEvent;

namespace OtusProject.System.Zombie
{
    internal sealed class DeathSystem : IEcsRunSystem 
    {        
        private readonly EcsFilterInject<Inc<CurrentHealth, CurrentEntity, CurrentTransform>, Exc<DeadTag>> _filter;
        private readonly EcsPoolInject<DeathEvent> _deadEvent;
        private readonly EcsPoolInject<DeadTag> _deadTag;
        private readonly EcsPoolInject<DeathRequest> _dethRequest;
        private readonly EcsPoolInject<DropRequest> _dropRequest;
        private readonly EcsPoolInject<LifeTimerRequest> _lifeTimerRequest;
        private EcsCustomInject<OnDeathInECS> _onDeath;
        public void Run (IEcsSystems systems) 
        {
            foreach (var entity in _filter.Value)
            {
                if (_filter.Pools.Inc1.Get(entity).Value <= 0)
                {
                    _deadTag.Value.Add(entity);
                    _deadEvent.Value.Add(entity);
                    _dethRequest.Value.Add(entity);
                    _dropRequest.Value.Add(entity);
                    _lifeTimerRequest.Value.Add(entity);
                    _onDeath.Value.OnDeathEvent(_filter.Pools.Inc2.Get(entity).Value, _filter.Pools.Inc3.Get(entity).Value);
                }
            }
        }
    }
}