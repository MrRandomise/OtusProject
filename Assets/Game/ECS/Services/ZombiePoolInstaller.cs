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
            entity.AddData(new SpawnActivePool { Value = _activePool });
            entity.AddData(new SpawnInActivePool { Value = _inActivePool });
        }

        protected override void Dispose(Entity entity)
        {

        }
    }
}
