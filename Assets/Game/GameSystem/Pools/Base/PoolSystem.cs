using Codice.Client.BaseCommands.Merge;
using UnityEngine;
using Zenject;

namespace OtusProject.Pools
{
    public sealed class PoolSystem
    {
        private IPoolView _pool;
        [Inject]
        private PoolCreator _poolCreator;
        private PoolBase<GameObject> _poolBase;

        public PoolSystem(IPoolView pool)
        {
            _pool = pool;
            _poolBase = new PoolBase<GameObject>(Preload, GetAction, ReturnAction);
            _poolCreator = new PoolCreator();
        }

        public GameObject Preload()
        {
            var t = _poolCreator.CreatObject(_pool.GetGameObject(), _pool.GetSpawnPoint(), _pool.GetActivePools());
            return t;
        }
        public void GetAction(GameObject prefab) => prefab.transform.SetParent(_pool.GetActivePools());
        public void ReturnAction(GameObject prefab) => prefab.transform.SetParent(_pool.GetInActivePools());
        public GameObject ActivePool() => _poolBase.Get();
        public void InActivePool(GameObject obj) => _poolBase.Return(obj);
    }
}
