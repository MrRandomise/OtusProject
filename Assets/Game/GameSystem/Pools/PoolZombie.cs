using EcsEngine;
using Leopotam.EcsLite.Entities;
using OtusProject.Waves;
using OtusProject.Component;
using System;
using UnityEngine;
using Zenject;

namespace OtusProject.Pools
{

    public sealed class PoolZombie: ITickable, IDisposable, IInActiveEvent
    {
        private WaveSystem _waveSystem;
        private PoolSystem _poolSystem;
        private PoolZombieView _view;
        private float _currentTimer = 0;
        private bool _startTimer = false;
        private int _currentCountZombie = 0;
        private int _countZombie = 0;

        PoolZombie(WaveSystem waveSystem, PoolZombieView view, EcsStartup ecsStartup)
        {
            _waveSystem = waveSystem;
            _waveSystem.OnStartWave += StartSpawnActivePool;
            _waveSystem.OnStopWave += StopSpawnActivePool;
            _view = view;
            _countZombie = _view.InitialCountZombie;
            _poolSystem = new PoolSystem(_view, ecsStartup);
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
                if(_currentTimer >= _view.SpawnTimeout)
                {
                    _currentCountZombie++;
                    _currentTimer = 0;
                    var zombie = _poolSystem.ActivePool();
                    zombie.GetData<Pool>().Value = this;
                    if (_currentCountZombie == _view.InitialCountZombie)
                    {
                        _currentCountZombie = 0;
                        _countZombie *= 2;
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