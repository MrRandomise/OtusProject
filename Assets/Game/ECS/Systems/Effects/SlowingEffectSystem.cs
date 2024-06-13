using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component;
using OtusProject.Component.Request;

namespace OtusProject.System.Effects
{
    sealed class SlowingEffectSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<SlowingRequest, NavAgent>, Exc<DeadTag>> _filter;
        private readonly EcsPoolInject<DamageRequest> _damageRequest;
        private readonly EcsPoolInject<SlowingRequest> _effect;
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                ref var agent = ref _filter.Pools.Inc2.Get(entity).Value;
                var damage = _filter.Pools.Inc1.Get(entity).Damage;
                var speedRate = _filter.Pools.Inc1.Get(entity).SpeedRate;
                agent.speed -= speedRate;
                if (agent.speed <= 0)
                {
                    agent.speed = 0;
                }
                _damageRequest.Value.Add(entity).Value = damage;
                _effect.Value.Del(entity);
            }
        }
    }
}