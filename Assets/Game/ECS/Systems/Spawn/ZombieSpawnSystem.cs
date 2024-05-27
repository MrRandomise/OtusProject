using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using OtusProject.Component.Spawn;
using UnityEngine;
using System;
using OtusProject.Component.Zombie;
using OtusProject.Component.Events;
using OtusProject.Component.Request;
using OtusProject.Component.Bullet;

namespace OtusProject.System.Spawn
{
    internal sealed class ZombieSpawnSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<SpawnCountZombie, SpawnPoints, SpawnPrefab, SpawnTimeout, ZombieTarget, SpawnWave>, Exc<InactiveTag, ZombieAddPoolRequest>> _filter;
        private readonly EcsFilterInject<Inc<SpawnActivePool>> _poolFilter;
        private readonly EcsFilterInject<Inc<ZombieTag, InactiveTag>, Exc<ZombieAddPoolRequest>> _poolInActive;
        private readonly EcsCustomInject<EntityManager> _entityManager;
        private readonly EcsPoolInject<SpawnEvents> _spawnEvent;
        private readonly EcsPoolInject<StartSpawnRequest> _startSpawn;
        private readonly EcsPoolInject<ZombieAddPoolRequest> _respawnEvent;
        private readonly EcsPoolInject<BulletEffects> _effects;
        private int _spawnCount = 0;
        private float _currentSpawnTime = 0;
        public void Run(IEcsSystems systems)
        {
            var poolEntity = -1;
            var poolInActive = -1;
            _currentSpawnTime += Time.deltaTime;

            foreach (var entity in _poolFilter.Value)
            {
                poolEntity = entity;
            }

            if (poolEntity == -1)
            {
                throw new Exception("No unit pool container found!");
            }


            foreach (var entity in _poolInActive.Value)
            {
                poolInActive = entity;

            }

            foreach (var entity in _filter.Value)
            {
                if(_startSpawn.Value.Has(entity))
                {
                    var timeout = _filter.Pools.Inc4.Get(entity);

                    if (_currentSpawnTime >= timeout.Value)
                    {
                        if(poolInActive == -1)
                        {
                            var unit = _filter.Pools.Inc3.Get(entity).Value;
                            var index = UnityEngine.Random.Range(0, _filter.Pools.Inc2.Get(entity).Value.Count);
                            var point = _filter.Pools.Inc2.Get(entity).Value[index];
                            var zombieIndex = UnityEngine.Random.Range(0, _filter.Pools.Inc3.Get(entity).Value.Count);
                            var prefab = _filter.Pools.Inc3.Get(entity).Value[zombieIndex];
                            var newUnit = _entityManager.Value.Create(prefab, point.transform.position,
                                prefab.transform.rotation, _poolFilter.Pools.Inc1.Get(poolEntity).Value);
                            newUnit.AddData(new ZombieTarget { Value = _filter.Pools.Inc5.Get(entity).Value });
                            newUnit.AddData(new ZombieCurrEntity { Value = newUnit }); 
                        }
                        else
                        {
                            _respawnEvent.Value.Add(poolInActive);
                        }
                        _spawnEvent.Value.Add(entity);
                        _currentSpawnTime = 0;
                        _spawnCount++;

                    }
                    if(_spawnCount == _filter.Pools.Inc1.Get(entity).Value)
                    {
                        _startSpawn.Value.Del(entity);
                        _spawnCount = 0;
                    }
                }                
            }
        }
    }
}