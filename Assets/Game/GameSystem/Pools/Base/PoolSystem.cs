using UnityEngine;
using Leopotam.EcsLite.Entities;
using EcsEngine;

namespace OtusProject.Pools
{
    public sealed class PoolSystem
    {
        private IPoolView _pool;
        private PoolBase<Entity> _poolBase;
        private EcsStartup _ecsStartup;
        public PoolSystem(IPoolView pool, EcsStartup ecsStartup)
        {
            _pool = pool;
            _ecsStartup = ecsStartup;
            _poolBase = new PoolBase<Entity>(Preload, GetAction, ReturnAction);
        }

        public Entity Preload() => _ecsStartup.EntityManager.Create(_pool.GetGameObject(), _pool.GetSpawnPoint(), Quaternion.identity, _pool.GetActivePools());
        public void GetAction(Entity prefab) => prefab.transform.SetParent(_pool.GetActivePools());
        public void ReturnAction(Entity prefab) => prefab.transform.SetParent(_pool.GetInActivePools());
        public Entity ActivePool() => _poolBase.Get();
        public void InActivePool(Entity obj) => _poolBase.Return(obj);
    }
}
