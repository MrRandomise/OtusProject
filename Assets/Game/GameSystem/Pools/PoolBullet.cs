using EcsEngine;
using Leopotam.EcsLite.Entities;
using OtusProject.Component;
using OtusProject.Component.Bullet;
using OtusProject.Weapons;

namespace OtusProject.Pools
{

    public sealed class PoolBullet : IInActiveEvent
    {
        private PoolSystem _poolSystem;
        private PoolBulletView _view;
        private Entity _bullet;

        PoolBullet(PoolBulletView view, EcsStartup ecsStartup)
        {
            _view = view;
            _poolSystem = new PoolSystem(_view, ecsStartup);
        }

        public void BulletInitial(IWeapon weapon)
        {
            var bulletConfig = weapon.GetBulletConfig();
            _view.PrefabBullet = bulletConfig.Bullet;
            _view.SpawnPoint = weapon.GetBulletPoint();
            _bullet = _poolSystem.ActivePool();
            _bullet.GetData<Speed>().Value = bulletConfig.Speed;
            _bullet.GetData<MoveDirection>().Value = weapon.GetBulletPoint().forward;
            _bullet.GetData<LifeTime>().Value = bulletConfig.LifeTime;
            _bullet.GetData<Pool>().Value = this;
            _bullet.GetData<BulletEffects>().Value = bulletConfig.Effects;
            
        }

        public void InActiveEvent(Entity _entity)
        {
            _poolSystem.InActivePool(_entity);
        }
    }
}