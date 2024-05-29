using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Events;
using OtusProject.Component.Request;
using OtusProject.Component.Spawn;
using OtusProject.Component.Zombie;
using UnityEngine;

namespace Client
{
    internal sealed class ZombieStartSpawn : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<StartWaveRequest>> _filter;
        private readonly EcsFilterInject<Inc<SpawnCountZombie, ZombieCurrCount, SpawnReadyTimer, CurrTimerWave>> _spawnData;
        private readonly EcsPoolInject<StartSpawnRequest> _spawnPool;
        private readonly EcsPoolInject<StartWaveRequest> _waveRequest;
        private readonly EcsPoolInject<ChangeViewEvent> _changeView;
        private readonly int _waveComponent = 0;
        private int _waveCount = 1;
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                ref var currTime = ref _spawnData.Pools.Inc4.Get(entity).Value;
                currTime += Time.deltaTime;
                foreach (var spawn in _spawnData.Value)
                {
                    var spawnCount = _spawnData.Pools.Inc1.Get(spawn);
                    var SpawnReadyTimer = _spawnData.Pools.Inc3.Get(spawn);
                    if (!_changeView.Value.Has(entity))
                    {
                        _changeView.Value.Add(entity).Value = _waveCount;
                    }
                    else
                    {
                        _changeView.Value.Get(entity).Value = _waveCount;
                    }
                    if (currTime >= SpawnReadyTimer.Value)
                    {
                        _spawnData.Pools.Inc2.Get(spawn).Value = spawnCount.Value;
                        _spawnPool.Value.Add(entity);
                        _waveRequest.Value.Del(entity);
                        currTime = 0;
                        _waveCount++;
                        _changeView.Value.Get(entity).ViewValue = _waveComponent;
                    }
                }
            }
        }
    }
}