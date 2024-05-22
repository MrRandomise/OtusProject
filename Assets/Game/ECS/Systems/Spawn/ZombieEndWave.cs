using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Zombie;
using OtusProject.Component.Request;
using OtusProject.Component.View;
using UnityEngine;
using OtusProject.Component.Spawn;

namespace OtusProject.System.Spawn
{

    internal sealed class ZombieEndWave : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<ZombieDeathRequest>> _filter;
        private readonly EcsFilterInject<Inc<ZombieCurrCount, BuyMenu, SpawnWave, SpawnCountZombie, SpawnOpenShoopTimer>> _filterInstal;
        private readonly EcsPoolInject<ZombieDeathRequest> _zombieRequest;
        private float _currentTime = 0;

        public void Run(IEcsSystems systems)
        {
            _currentTime += Time.deltaTime;
            foreach (var entity in _filter.Value)
            {
                foreach (var installer in _filterInstal.Value)
                {
                    var timeout = _filterInstal.Pools.Inc5.Get(installer);
                    _filterInstal.Pools.Inc1.Get(installer).Value -= 1;
                    if(_filterInstal.Pools.Inc1.Get(installer).Value == 0)
                    {
                        _filterInstal.Pools.Inc3.Get(installer).Value += 1;
                        _filterInstal.Pools.Inc4.Get(installer).Value *= _filterInstal.Pools.Inc3.Get(installer).Value;
                        if (_currentTime >= timeout.Value)
                        {
                            _filterInstal.Pools.Inc2.Get(installer).Value.SetActive(true);
                        }
                    }
                    _zombieRequest.Value.Del(entity);
                }
            }
        }
    }
}