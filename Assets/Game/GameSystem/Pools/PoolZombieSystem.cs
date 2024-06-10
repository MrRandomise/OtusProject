using EcsEngine;
using Leopotam.EcsLite.Entities;
using OtusProject.Waves;
using OtusProject.Component;
using System;
using UnityEngine;
using Zenject;
using OtusProject.Component.Request;

namespace OtusProject.Pools
{

    public sealed class PoolZombieSystem: ITickable, IDisposable, IInActiveEvent
    {
        private WaveSystem _waveSystem;
        private PoolSystem _poolSystem;
        private PoolZombieManager _manager;
        private float _currentTimer = 0;
        private bool _startTimer = false;
        private int _currentCountZombie = 0;

        PoolZombieSystem(WaveSystem waveSystem, PoolZombieManager manager, EcsStartup ecsStartup)
        {
            _waveSystem = waveSystem;
            _waveSystem.OnStartWave += StartSpawnActivePool;
            _waveSystem.OnStopWave += StopSpawnActivePool;
            _manager = manager;
            _poolSystem = new PoolSystem(_manager, ecsStartup);
        }

        private void StartSpawnActivePool()
        {
            _startTimer = true;
        }

        private void StopSpawnActivePool()
        {
            _startTimer = false;
        }

        public void Tick()
        {
            if(_startTimer)
            {
                _currentTimer += Time.deltaTime;
                if(_currentTimer >= _manager.SpawnTimeout)
                {
                    _currentCountZombie++;
                    _currentTimer = 0;
                    var zombie = _poolSystem.ActivePool();
                    InitialZombie(zombie);
                    if (_currentCountZombie == _manager.InitialCountZombie)
                    {
                        _currentCountZombie = 0;
                        _manager.InitialCountZombie *= 2;
                        _startTimer = false;
                    }
                }
            }
        }

        public void InActiveEvent(Entity _entity)
        {
            _poolSystem.InActivePool(_entity);
        }


        private void InitialZombie(Entity zombie)
        {
            zombie.GetData<Pool>().Value = this;
            zombie.GetData<CurrentHealth>().Value = zombie.GetData<MaxHealth>().Value;
            if (zombie.HasData<InactiveTag>())
            {
                zombie.RemoveData<DeathRequest>();
            }
            if (zombie.HasData<InactiveTag>())
            {
                zombie.RemoveData<InactiveTag>();
            }
            if (zombie.HasData<DeadTag>())
            {
                zombie.RemoveData<DeadTag>();
            }
        }

        public void Dispose()
        {
            _waveSystem.OnStartWave -= StartSpawnActivePool;
            _waveSystem.OnStopWave -= StopSpawnActivePool;
        }
    }
}