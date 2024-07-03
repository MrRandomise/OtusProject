using UnityEngine;

namespace OtusProject.Pools
{
    public interface IFactoryPool<T>
    {
        public T CreatePrefab(T prefab, Vector3 position, Transform parent);
    }
}