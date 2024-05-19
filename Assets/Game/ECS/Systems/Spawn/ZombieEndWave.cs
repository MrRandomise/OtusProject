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
        private readonly EcsFilterInject<Inc<ZombieCurrCount, BuyMenu, SpawnWave, SpawnCountZombie>> _filterInstal;
        private readonly EcsPoolInject<ZombieDeathRequest> _zombieRequest;
        public void Run(IEcsSystems systems)
        {
            foreach(var entity in _filter.Value)
            {
                foreach (var installer in _filterInstal.Value)
                {
                    _filterInstal.Pools.Inc1.Get(installer).Value -= 1;
                    if(_filterInstal.Pools.Inc1.Get(installer).Value == 0)
                    {
                        _filterInstal.Pools.Inc3.Get(installer).Value += 1;
                        _filterInstal.Pools.Inc4.Get(installer).Value *= _filterInstal.Pools.Inc3.Get(installer).Value;
                        _filterInstal.Pools.Inc2.Get(installer).Value.SetActive(true);
                    }
                    _zombieRequest.Value.Del(entity);
                }
            }
        }
    }
}