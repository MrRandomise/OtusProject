using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component;
using OtusProject.Component.Events;
using OtusProject.Component.Request;
using OtusProject.ECSEvent;

namespace OtusProject.System.Zombie
{
    sealed class DamageSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<DamageRequest, CurrentHealth, CurrentEntity> , Exc<DeadTag>> _filter;
        private readonly EcsPoolInject<DamageRequest> _damageRequest;
        private readonly EcsPoolInject<DamageEvent> _damageEvent;
        
        private EcsCustomInject<OnHitInECS> _oHit;
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                ref var health = ref  _filter.Pools.Inc2.Get(entity).Value;
                var damage = _filter.Pools.Inc1.Get(entity).Value;
                health -= damage;
                _oHit.Value.HitEvent(_filter.Pools.Inc3.Get(entity).Value);
                _damageEvent.Value.Add(entity);
                _damageRequest.Value.Del(entity);
            }
        }
    }
}