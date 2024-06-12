using EcsEngine;
using Leopotam.EcsLite.Entities;
using OtusProject.Component.Request;
using OtusProject.ECSEvent;
using System;
using OtusProject.Component;
using UnityEngine;
using System.Security.Cryptography;

namespace OtusProject.Pools
{
    public sealed class PoolResourcesSystem : IInActiveEvent, IDisposable
    { 
        private PoolSystem _poolSystem;
        private PoolResourcesManager _manager;
        private OnDropInECS _onDropInECS;

        PoolResourcesSystem(PoolResourcesManager view, EcsStartup ecsStartup, OnDropInECS onDropInECS)
        {
            _manager = view;
            _poolSystem = new PoolSystem(_manager, ecsStartup);
            _onDropInECS = onDropInECS;
            _onDropInECS.OnDrop += ResourceInitial;
        }

        public void ResourceInitial(Entity res, Transform pos)
        {
            _manager.Prefab = res;
            _manager.SpawnPoint = pos;
            res = _poolSystem.ActivePool();
            res.GetData<Pool>().Value = this;
            if(res.HasData<LifeTimerRequest>())
            {
                res.GetData<CurrentTimer>().Value = 0;
            }
            else
            {
                res.AddData(new LifeTimerRequest());
            }
        }

        public void InActiveEvent(Entity _entity)
        {
            _poolSystem.InActivePool(_entity);
        }

        public void Dispose()
        {
            _onDropInECS.OnDrop -= ResourceInitial;
        }
    }
}