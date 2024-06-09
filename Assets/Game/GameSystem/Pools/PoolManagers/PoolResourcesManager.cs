using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace OtusProject.Pools
{
    public sealed class PoolResourcesManager : MonoBehaviour, IPoolView
    {
        [HideInInspector] public Transform SpawnPoint;
        [SerializeField] private Transform _activePool;
        [SerializeField] private Transform _inActivePool;
        [HideInInspector] public Entity Prefab;
        public float SpawnTimeout = 1.5f;

        public Transform GetActivePools()
        {
            return _activePool;
        }

        public Entity GetGameObject()
        {
            return Prefab;
        }

        public Transform GetInActivePools()
        {
            return _inActivePool;
        }

        public Vector3 GetSpawnPoint()
        {
            return SpawnPoint.position;
        }
    }
}

