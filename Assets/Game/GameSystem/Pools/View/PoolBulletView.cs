using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace OtusProject.Pools
{
    public sealed class PoolBulletView : MonoBehaviour, IPoolView
    {
        public Transform SpawnPoint;
        public Entity PrefabBullet;
        [SerializeField] private Transform ActivePool;
        [SerializeField] private Transform InActivePool;

        public Transform GetActivePools()
        {
            return ActivePool;
        }

        public Transform GetInActivePools()
        {
            return InActivePool;
        }

        public Entity GetGameObject()
        {
            return PrefabBullet;
        }

        public Vector3 GetSpawnPoint()
        {
            return SpawnPoint.position;
        }

    }
}

