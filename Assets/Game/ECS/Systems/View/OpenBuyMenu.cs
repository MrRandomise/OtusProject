using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;
using OtusProject.Component.Request;
using OtusProject.Component.View;
using OtusProject.Component.Spawn;
using System.Threading;

namespace OtusProject.Systems.View
{
    internal sealed class OpenBuyMenu : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<BuyMenuRequest, BuyMenu, SpawnOpenShoopTimer, CurrBuyMenuTimer>> _filter;
        private readonly EcsPoolInject<BuyMenuRequest> _buyMenuRequest;
        public void Run(IEcsSystems systems)
        {
           foreach(var entity in _filter.Value)
           {
                ref var timer = ref _filter.Pools.Inc4.Get(entity).Value;
                timer += Time.deltaTime;
                var timeout = _filter.Pools.Inc3.Get(entity);
                if (timer >= timeout.Value)
                {
                    _filter.Pools.Inc2.Get(entity).Value.SetActive(true);
                    _buyMenuRequest.Value.Del(entity);
                    timer = 0;
                }
            }

        }
    }
}