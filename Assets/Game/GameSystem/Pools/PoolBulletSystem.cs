using EcsEngine;
using Leopotam.EcsLite.Entities;
using OtusProject.Component;
using OtusProject.Component.Bullet;
using OtusProject.Component.Request;
using OtusProject.Weapons;

namespace OtusProject.Pools
{

    public sealed class PoolBulletSystem : IInActiveEvent
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
            _manager.PrefabBullet = bulletConfig.Bullet;
            _manager.SpawnPoint = weapon.GetBulletPoint();
            _bullet = _poolSystem.ActivePool();
            _bullet.GetData<Speed>().Value = bulletConfig.Speed;
            _bullet.GetData<MoveDirection>().Value = weapon.GetBulletPoint().forward;
            _bullet.GetData<LifeTime>().Value = bulletConfig.LifeTime;
            _bullet.GetData<Pool>().Value = this;
            _bullet.GetData<BulletEffects>().Value = bulletConfig.Effects;
            _bullet.AddData(new LifeTimerRequest());
        }

        public void InActiveEvent(Entity _entity)
        {
            _poolSystem.InActivePool(_entity);
        }
    }
}