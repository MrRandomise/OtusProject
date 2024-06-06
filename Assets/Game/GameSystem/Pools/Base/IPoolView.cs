using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace OtusProject.Pools
{
    public interface IPoolView
    {
        public Transform GetActivePools();
        public Transform GetInActivePools();
        public Entity GetGameObject();
        public Vector3 GetSpawnPoint();
    }
}

