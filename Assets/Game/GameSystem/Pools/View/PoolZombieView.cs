using Leopotam.EcsLite.Entities;
using System.Collections.Generic;
using UnityEngine;

namespace OtusProject.Pools
{
    public sealed class PoolZombieView : MonoBehaviour, IPoolView
    {
        [SerializeField] private List<Transform> SpawnPoint;
        [SerializeField] private Transform ActivePool;
        [SerializeField] private Transform InActivePool;
        [SerializeField] private List<Entity> SpawnPrefab = new List<Entity>();
        public float SpawnTimeout = 1.5f;
        public int InitialCountZombie = 1;

        public Transform GetActivePools()
        {
            return ActivePool;
        }

        public Entity GetGameObject()
        {
            var index = Random.Range(0, SpawnPrefab.Count);
            return SpawnPrefab[index];
        }

        public Transform GetInActivePools()
        {
            return InActivePool;
        }

        public Vector3 GetSpawnPoint()
        {
            var index = Random.Range(0, SpawnPoint.Count);
            return SpawnPoint[index].position;
        }

    }
}

