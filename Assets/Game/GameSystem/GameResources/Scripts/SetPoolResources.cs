using Leopotam.EcsLite.Entities;
using OtusProject.Player;
using OtusProject.Pools;
using System;

namespace OtusProject.RecourcesConfig
{
    public class SetPoolResources : IDisposable
    {
        private PoolResourcesSystem _poolSystem;
        private GetResources _getResources;

        SetPoolResources(PoolResourcesSystem poolSystem, CharacterInstaller characterInstaller)
        {
            _poolSystem = poolSystem;
            _getResources = characterInstaller.GetComponent<GetResources>();
            _getResources.onGetResources += InActiveResource;
        }

        private void InActiveResource(ResourcesInstaler key)
        {
            var res = key.GetComponent<Entity>();
            _poolSystem.InActiveEvent(res);
        }

        public void Dispose()
        {
            _getResources.onGetResources -= InActiveResource;
        }
    }
}
