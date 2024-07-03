namespace OtusProject.Pools
{
    public sealed class PoolSystem<T> where T : UnityEngine.Component
    {
        private IPoolView<T> _pool;
        private PoolBase<T> _poolBase;
        private IFactoryPool<T> _factory;

        public PoolSystem(IPoolView<T> pool, IFactoryPool<T> factory)
        {
            _pool = pool;
            _factory = factory;
            _poolBase = new PoolBase<T>(Preload, GetAction, ReturnAction);
        }

        public T Preload() => _factory.CreatePrefab(_pool.GetGameObject(), _pool.GetSpawnPoint(), _pool.GetActivePools());
        public void GetAction(T prefab) => prefab.transform.SetParent(_pool.GetActivePools());
        public void ReturnAction(T prefab) => prefab.transform.SetParent(_pool.GetInActivePools());
        public T ActivePool()
        {
            var prefab = _poolBase.Get();
            prefab.transform.position = _pool.GetSpawnPoint();
            return prefab;
        }

        public void InActivePool(T obj) => _poolBase.Return(obj);
    }
}
