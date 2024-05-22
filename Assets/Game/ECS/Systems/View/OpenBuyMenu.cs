using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;
using OtusProject.Component.Request;
using OtusProject.Component.View;
using OtusProject.Component.Spawn;

namespace OtusProject.Systems.View
{
    internal sealed class OpenBuyMenu : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<BuyMenuRequest, BuyMenu, SpawnOpenShoopTimer>> _filter;
        private readonly EcsPoolInject<BuyMenuRequest> _buyMenuRequest;
        private float _timer;
        public void Run(IEcsSystems systems)
        {
           foreach(var entity in _filter.Value)
           {
                _timer += Time.deltaTime;
                var timeout = _filter.Pools.Inc3.Get(entity);
                if (_timer >= timeout.Value)
                {
                    _filter.Pools.Inc2.Get(entity).Value.SetActive(true);
                    _buyMenuRequest.Value.Del(entity);
                }
            }

        }
    }
}