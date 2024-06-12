using EcsEngine;
using Leopotam.EcsLite.Entities;
using OtusProject.Component;
using OtusProject.Component.Bullet;
using OtusProject.Component.Request;
using OtusProject.Weapons;
using OtusProject.Content;
using System;

namespace OtusProject.Pools
{

    public sealed class PoolBulletSystem : IInActiveEvent, IDisposable
    {
        private PoolSystem _poolSystem;
        private PoolBulletManager _manager;
        private Entity _bullet;

        PoolBulletSystem(PoolBulletManager view, EcsStartup ecsStartup)
        {
            _manager = view;
            _poolSystem = new PoolSystem(_manager, ecsStartup);
        }

        public void BulletInitial(IWeapon weapon)
        {
            var bulletConfig = weapon.GetBulletConfig();
            BulleCollision.OnBulletHit += InActiveEvent;
            _manager.PrefabBullet = bulletConfig.Bullet;
            _manager.SpawnPoint = weapon.GetBulletPoint();
            _bullet = _poolSystem.ActivePool();
            _bullet.GetData<Speed>().Value = bulletConfig.Speed;
            _bullet.GetData<MoveDirection>().Value = weapon.GetBulletPoint().forward;
            _bullet.GetData<LifeTime>().Value = bulletConfig.LifeTime;
            _bullet.GetData<Pool>().Value = this;
            _bullet.GetData<BulletEffects>().Value = bulletConfig.Effects;
            if(_bullet.TryGetData(out LifeTimerRequest data))
            {
                _bullet.GetData<CurrentTimer>().Value = 0;
            }
            else
            {
                _bullet.AddData(new LifeTimerRequest());
            }
        }

        public void InActiveEvent(Entity _entity)
        {
            _entity.RemoveData<LifeTimerRequest>();
            _entity.GetData<CurrentTimer>().Value = 0;
            _poolSystem.InActivePool(_entity);
        }

        public void Dispose()
        {
            BulleCollision.OnBulletHit -= InActiveEvent;
        }

    }
}