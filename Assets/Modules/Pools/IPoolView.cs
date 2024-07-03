using UnityEngine;

namespace OtusProject.Pools
{
    public interface IPoolView<T>
    {
        public Transform GetActivePools();
        public Transform GetInActivePools();
        public T GetGameObject();
        public Vector3 GetSpawnPoint();
    }
}

