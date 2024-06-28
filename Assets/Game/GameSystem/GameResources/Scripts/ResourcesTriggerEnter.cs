using Leopotam.EcsLite.Entities;
using OtusProject.Pools;
using Zenject;
using UnityEngine;

namespace OtusProject.RecourcesConfig
{
    public class ResourcesTriggerEnter : MonoBehaviour
    {
        [SerializeField] private Entity _currentEntity;
        [SerializeField] private ResourceConfig _config;
        private PoolResourcesSystem _poolSystem;
        private ResourcesStorage _resourcesStorage;
        private string _id;

        [Inject]
        private void Construct(PoolResourcesSystem poolSystem, ResourcesStorage resourcesStorage)
        {
            _poolSystem = poolSystem;
            _resourcesStorage = resourcesStorage;
            _id = _config.NameResources;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _poolSystem.InActiveEvent(_currentEntity);
                _resourcesStorage.SetAmmountResources(_id, 1);
            }
        }
    }
}
