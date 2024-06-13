using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component;
using OtusProject.Component.Request;
using UnityEngine;

namespace OtusProject.System.Effects
{
    sealed class BleendingEffectSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<BleendingRequest>, Exc<DeadTag>> _filter;
        private readonly EcsPoolInject<DamageRequest> _damageRequest;
        private readonly EcsPoolInject<BleendingRequest> _effect;
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var damage = _filter.Pools.Inc1.Get(entity).DamagePerSec;
                ref var timer = ref _filter.Pools.Inc1.Get(entity).TotalTimer;
                var fromTime = _filter.Pools.Inc1.Get(entity).FromTime;
                ref var currentTime = ref _filter.Pools.Inc1.Get(entity).CurrentTimer;
                currentTime += Time.deltaTime;

                if (currentTime >= fromTime)
                {
                    currentTime = 0;
                    _damageRequest.Value.Add(entity).Value = damage;
                    timer -= fromTime;
                }
                
                if (currentTime >= timer)
                {
                    _effect.Value.Del(entity);
                }
            }
        }
    }
}