using Leopotam.EcsLite.Entities;
using OtusProject.Component.Request;
using OtusProject.Component;
using System;

namespace OtusProject.Pools
{
    public sealed class PoolInitializeSpawnZombie : IDisposable
    {
        private PoolZombieSystem _poolZombieSystem;

        PoolInitializeSpawnZombie(PoolZombieSystem poolZombieSystem)
        {
            _poolZombieSystem = poolZombieSystem;
            _poolZombieSystem.OnSpawnEvent += InitialZombie;
        }

        private void InitialZombie(Entity zombie)
        {
            zombie.GetData<CurrentHealth>().Value = zombie.GetData<MaxHealth>().Value;
            if (zombie.HasData<InactiveTag>())
            {
                zombie.RemoveData<DeathRequest>();
            }
            if (zombie.HasData<InactiveTag>())
            {
                zombie.RemoveData<InactiveTag>();
            }
            if (zombie.HasData<DeadTag>())
            {
                zombie.RemoveData<DeadTag>();
            }
        }

        public void Dispose()
        {
            _poolZombieSystem.OnSpawnEvent -= InitialZombie;
        }
    }
}
