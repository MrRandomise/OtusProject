using OtusProject.Component.Spawn;
using System.Collections.Generic;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace OtusProject.Content
{
    public class SpawnInstaller : EntityInstaller
    {
        [SerializeField] private List<Transform> _spawnPoint;
        [SerializeField] private Entity _spawnPrefab;
        [SerializeField] private float _spawnTimeout;
        [SerializeField] private int _countZombie;
        protected override void Install(Entity entity)
        {
            entity.AddData(new SpawnTimeout { value = _spawnTimeout });
            entity.AddData(new SpawnPrefab { value = _spawnPrefab });
            entity.AddData(new SpawnPoints { value = _spawnPoint });
            entity.AddData(new SpawnCountZombie { value = _countZombie });
        }

        protected override void Dispose(Entity entity)
        {

        }
    }
}

