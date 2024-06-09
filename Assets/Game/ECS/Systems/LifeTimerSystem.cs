using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component;
using OtusProject.Component.Request;
using UnityEngine;

namespace OtusProject.System.Zombie
{
    internal sealed class LifeTimerSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<LifeTimerRequest, LifeTime, CurrentTimer, Pool, CurrentEntity>> _filter;
        private EcsPoolInject<LifeTimerRequest> _timeRequest;
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                ref var timer = ref _filter.Pools.Inc3.Get(entity);
                var lifeTime = _filter.Pools.Inc2.Get(entity);
                var pool = _filter.Pools.Inc4.Get(entity);
                var thisEntity = _filter.Pools.Inc5.Get(entity);
                timer.Value += Time.deltaTime;
                if(timer.Value >= lifeTime.Value)
                {
                    timer.Value = 0;
                    _timeRequest.Value.Del(entity);
                    pool.Value.InActiveEvent(thisEntity.Value);
                }
            }
        }
    }
}