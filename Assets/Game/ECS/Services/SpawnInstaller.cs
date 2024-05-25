using OtusProject.Component.Spawn;
using System.Collections.Generic;
using Leopotam.EcsLite.Entities;
using UnityEngine;
using OtusProject.Component.Zombie;
using OtusProject.Component.View;
using OtusProject.Component.Request;
using OtusProject.View;
using Zenject;

namespace OtusProject.Content
{
    public sealed class SpawnInstaller : EntityInstaller
    {
        [SerializeField] private List<Transform> _spawnPoint;
        [SerializeField] private List<Entity> _spawnPrefab = new List<Entity>();
        [SerializeField] private Transform _target;
        [SerializeField] private int _wave;
        [SerializeField] private float _spawnTimeout;
        [SerializeField] private int _countZombie;
        [SerializeField] private GameObject _buyMenu;
        [SerializeField] private float _readyTimer;
        [SerializeField] private float _openShoopTimer;
        [SerializeField] private Transform _activePool;
        [SerializeField] private Transform _inActivePool;
        private ZombieView _zombieView;
        private WaveView  _waveView;

        [Inject]
        private void Construct(ZombieView zombieView, WaveView waveView)
        {
            _zombieView = zombieView;
            _waveView = waveView;
        }

        protected override void Install(Entity entity)
        {
            entity.AddData(new BuyMenu { Value = _buyMenu });
            entity.AddData(new SpawnTimeout { Value = _spawnTimeout });
            entity.AddData(new SpawnPrefab { Value = _spawnPrefab });
            entity.AddData(new ZombieTarget { Value = _target });
            entity.AddData(new SpawnWave { Value = _wave });
            entity.AddData(new SpawnPoints { Value = _spawnPoint });
            entity.AddData(new SpawnCountZombie { Value = _countZombie });
            entity.AddData(new ZombieCurrCount { Value = _countZombie });
            entity.AddData(new SpawnReadyTimer { Value = _readyTimer });
            entity.AddData(new SpawnOpenShoopTimer { Value = _openShoopTimer });
            entity.AddData(new StartWaveRequest ());
            entity.AddData(new SpawnActivePool { Value = _activePool });
            entity.AddData(new SpawnInActivePool { Value = _inActivePool });
            entity.AddData(new ZombieViewComponent { Value = _zombieView });
            entity.AddData(new WaveViewComponent { Value = _waveView });
        }

        protected override void Dispose(Entity entity)
        {
        }
    }
}

