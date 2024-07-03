using EcsEngine;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace OtusProject.Pools
{
    public sealed class FactoryPool : IFactoryPool<Entity>
    {
        private EcsStartup _ecsStartup;

        FactoryPool(EcsStartup ecsStartup)
        {
            _ecsStartup = ecsStartup;
        }

        public Entity CreatePrefab(Entity prefab, Vector3 position, Transform parent)
        {
            return _ecsStartup.EntityManager.Create(prefab, position, Quaternion.identity, parent);
        }
    }
}

