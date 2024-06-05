using OtusProject.Waves;
using System;
using UnityEngine;
using Zenject;

namespace OtusProject.Pools
{

    public sealed class PoolZombie: ITickable, IDisposable
    {

        private WaveSystem _waveSystem;
        private PoolSystem _poolSystem;
        private PoolZombieView _view;
        private float _currentTimer = 0;
        private bool _startTimer = false;
        private int _currentCountZombie = 0;
        private int _countZombie = 0;

        PoolZombie(WaveSystem waveSystem, PoolZombieView view)
        {
            _waveSystem = waveSystem;
            _waveSystem.OnStartWave += StartSpawnActivePool;
            _waveSystem.OnStopWave += StopSpawnActivePool;
            _view = view;
            _countZombie = _view.InitialCountZombie;
            _poolSystem = new PoolSystem(_view);
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
                    _poolSystem.ActivePool();
                    if (_currentCountZombie == _view.InitialCountZombie)
                    {
                        _currentCountZombie = 0;
                        _countZombie *= 2;
                        _startTimer = false;
                    }
                }
            }
        }

        public void Dispose()
        {
            _waveSystem.OnStartWave -= StartSpawnActivePool;
            _waveSystem.OnStopWave -= StopSpawnActivePool;
        }
    }
}