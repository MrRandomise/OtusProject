using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using OtusProject.Component.Pool;
using OtusProject.Component.Spawn;
using OtusProject.Component.Events;
using UnityEngine;
using System;

namespace OtusProject.SpawnSystem
{
    sealed class ZombieSpawnSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<SpawnCountZombie, SpawnPoints, SpawnPrefab, SpawnTimeout>> _filter;
        private readonly EcsFilterInject<Inc<PoolContainerTag, SpawnActivePool>> _poolFilter;
        private readonly EcsCustomInject<EntityManager> _entityManager;
        private readonly EcsPoolInject<SpawnEvent> _spawnEventPool;
        private float _currentSpawnTime;
        private int _spawnCount = 0;
        public void Run(IEcsSystems systems)
        {
            var poolEntity = -1;
            foreach (var entity in _poolFilter.Value)
            {
                poolEntity = entity;
            }

            if (poolEntity == -1)
            {
                throw new Exception("No unit pool container found!");
            }
            _currentSpawnTime += Time.deltaTime;
            
            foreach (var entity in _filter.Value)
            {
                ref var timeout = ref _filter.Pools.Inc4.Get(entity);
                if (_currentSpawnTime >= timeout.value && _spawnCount < _filter.Pools.Inc1.Get(entity).value)
                {
                    var unit = _filter.Pools.Inc3.Get(entity).value;
                    var index = UnityEngine.Random.Range(0, _filter.Pools.Inc2.Get(entity).value.Count);
                    var point = _filter.Pools.Inc2.Get(entity).value[index];
                    _entityManager.Value.Create(unit, point.transform.position,
                        unit.transform.rotation, _poolFilter.Pools.Inc2.Get(poolEntity).value);
                    _spawnEventPool.Value.Add(entity);
                    _currentSpawnTime = 0;
                    _spawnCount++;
                }
            }
        }
    }
}