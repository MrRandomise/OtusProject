using EcsEngine;
using Leopotam.EcsLite.Entities;
using OtusProject.Waves;
using OtusProject.Component;
using System;
using UnityEngine;
using Zenject;
using OtusProject.Player;


namespace OtusProject.Pools
{

    public sealed class PoolZombieSystem: ITickable, IDisposable, IInActiveEvent
    {
        private Wave _waveSystem;
        private PoolSystem _poolSystem;
        private PoolZombieManager _manager;
        private Entity _entity;
        private float _currentTimer = 0;
        private bool _startTimer = false;
        private int _currentCountZombie = 0;
        public event Action<Entity> OnSpawnEvent;

        PoolZombieSystem(Wave waveSystem, PoolZombieManager manager, EcsStartup ecsStartup, CharacterInstaller characterInstaller)
        {
            _waveSystem = waveSystem;
            _waveSystem.OnTimerStartWave += StartSpawnActivePool;
            _waveSystem.OnTimerEndWave += StopSpawnActivePool;
            _manager = manager;
            _entity = characterInstaller.GetComponent<Entity>();
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
                    zombie.GetData<Target>().Value = _entity;
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
            _waveSystem.OnTimerStartWave -= StartSpawnActivePool;
            _waveSystem.OnTimerEndWave -= StopSpawnActivePool;
        }
    }
}