using Leopotam.EcsLite.Entities;
using OtusProject.Component;
using OtusProject.ECSEvent;
using OtusProject.Pools;
using System;
using UnityEngine;

namespace OtusProject.View
{
    public sealed class ZombieHealthBarPresenter : IDisposable
    {
        private OnHitInECS _onHitInECS;
        private PoolZombieSystem _poolZombieSystem;

        ZombieHealthBarPresenter(OnHitInECS onHitInECS, PoolZombieSystem poolZombieSystem)
        {
            _onHitInECS = onHitInECS;
            _onHitInECS.OnHitEvents += HealthBarUpdate;
            _poolZombieSystem = poolZombieSystem;
            _poolZombieSystem.OnSpawnEvent += FullHp;
        }


        private void HealthBarUpdate(Entity entity)
        {
            var h = (float)entity.GetData<CurrentHealth>().Value / entity.GetData<MaxHealth>().Value;
            if (h <= 0)
            {
                h = 0;
            }
            entity.GetData<HealthBar>().Value.localScale = new Vector3(h, 1, 1);
        }

        private void FullHp(Entity entity)
        {
            entity.GetData<HealthBar>().Value.localScale = new Vector3(1, 1, 1);
        }

        public void Dispose()
        {
            _poolZombieSystem.OnSpawnEvent -= FullHp;
        }
    }
}