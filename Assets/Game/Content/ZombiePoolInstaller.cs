using OtusProject.Component.Pool;
using OtusProject.Component.Spawn;
using Leopotam.EcsLite.Entities;
using UnityEngine;


namespace OtusProject.Content
{
    public class ZombiePoolInstaller : EntityInstaller
    {
        [SerializeField] private Transform _activePool;
        [SerializeField] private Transform _inActivePool;
        protected override void Install(Entity entity)
        {
            entity.AddData(new PoolContainerTag());
            entity.AddData(new SpawnActivePool { value = _activePool });
            entity.AddData(new SpawnInActivePool { value = _inActivePool });
        }

        protected override void Dispose(Entity entity)
        {

        }
    }
}
