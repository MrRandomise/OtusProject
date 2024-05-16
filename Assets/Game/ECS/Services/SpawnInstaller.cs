using OtusProject.Component.Spawn;
using System.Collections.Generic;
using Leopotam.EcsLite.Entities;
using UnityEngine;
using OtusProject.Component.Zombie;

namespace OtusProject.Content
{
    public sealed class SpawnInstaller : EntityInstaller
    {
        [SerializeField] private List<Transform> _spawnPoint;
        [SerializeField] private Entity _spawnPrefab;
        [SerializeField] private Transform _target;
        [SerializeField] private float _spawnTimeout;
        [SerializeField] private int _countZombie;
        protected override void Install(Entity entity)
        {
            entity.AddData(new SpawnTimeout { Value = _spawnTimeout });
            entity.AddData(new SpawnPrefab { Value = _spawnPrefab });
            entity.AddData(new ZombieTarget { Value = _target });
            entity.AddData(new SpawnPoints { Value = _spawnPoint });
            entity.AddData(new SpawnCountZombie { Value = _countZombie });
        }

        protected override void Dispose(Entity entity)
        {

        }
    }
}

