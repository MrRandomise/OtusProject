using EcsEngine;
using Leopotam.EcsLite.Entities;
using OtusProject.Waves;
using OtusProject.Component;
using System;
using UnityEngine;
using Zenject;


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
        public event Action<Entity> OnSpawnEvent;

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
                    zombie.GetData<Pool>().Value = this;
                    OnSpawnEvent?.Invoke(zombie);
                    if (_currentCountZombie == _manager.InitialCountZombie)
                    {
                        _currentCountZombie = 0;
                        _startTimer = false;
                    }
                }
            }
        }

        public void InActiveEvent(Entity _entity)
        {
            _poolSystem.InActivePool(_entity);
        }
        

        public void Dispose()
        {
            _waveSystem.OnStartWave -= StartSpawnActivePool;
            _waveSystem.OnStopWave -= StopSpawnActivePool;
        }
    }
}