using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Request;
using OtusProject.Component.Spawn;
using OtusProject.Component.Zombie;
using UnityEngine;

namespace Client {
    internal sealed class ZombieStartSpawn : IEcsRunSystem 
    {
        private readonly EcsFilterInject<Inc<StartWaveRequest>> _filter;
        private readonly EcsFilterInject<Inc<SpawnCountZombie, ZombieCurrCount, SpawnReadyTimer>> _spawnData;
        private readonly EcsPoolInject<StartSpawnRequest> _spawnPool;
        private readonly EcsPoolInject<StartWaveRequest> _waveRequest;
        private float _currTime = 0;
        public void Run (IEcsSystems systems) 
        {
            _currTime += Time.deltaTime;

            foreach (var entity in _filter.Value)
            {
                foreach (var spawn in _spawnData.Value) 
                {
                    var spawnCount = _spawnData.Pools.Inc1.Get(spawn);
                    var SpawnReadyTimer = _spawnData.Pools.Inc3.Get(spawn);

                    if (_currTime >= SpawnReadyTimer.Value)
                    {
                        _spawnData.Pools.Inc2.Get(spawn).Value = spawnCount.Value;
                        _waveRequest.Value.Del(entity);
                        _spawnPool.Value.Add(entity);
                        _currTime = 0;
                    }
                }
            }
        }
    }
}