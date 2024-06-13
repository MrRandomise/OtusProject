using Leopotam.EcsLite.Entities;
using OtusProject.Pools;
using Zenject;
using UnityEngine;

namespace OtusProject.RecourcesConfig
{
    public class ResourcesHitEvent : MonoBehaviour
    {
        private PoolResourcesSystem _poolSystem;
        private ResourcesStorage _resourcesStorage;
        private Entity _currentEntity;
        private string _id;

        [Inject]
        private void Construct(PoolResourcesSystem poolSystem, ResourcesStorage resourcesStorage)
        {
            _poolSystem = poolSystem;
            _resourcesStorage = resourcesStorage;
            _currentEntity = GetComponent<Entity>();
            _id = GetComponent<ResourcesInstaler>().Resources.name;
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
