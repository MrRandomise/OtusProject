using Leopotam.EcsLite.Entities;
using OtusProject.Component;
using OtusProject.Component.Bullet;
using OtusProject.Component.Request;
using OtusProject.Content;
using System;
using OtusProject.Inventary;
using OtusProject.Weapons;
namespace OtusProject.Pools
{
    public sealed class PoolBulletSystem : IInActiveEvent, IDisposable
    {
        private PoolSystem<Entity> _poolSystem;
        private PoolBulletManager _manager;
        private WeaponStorage _weapon;
        private BulletConfigProvider _configProvider;

        PoolBulletSystem(PoolBulletManager view, FactoryPool factoryPool, WeaponStorage weapon)
        {
            _manager = view;
            _weapon = weapon;
            _poolSystem = new PoolSystem<Entity>(_manager, factoryPool);
            _configProvider = new BulletConfigProvider();
        }

        public void BulletInitial()
        {
            _configProvider.TryGetBulletConfig(_weapon.GetActiveWeapon().Bullet, out var bulletConfig);
            BulleCollision.OnBulletHit += InActiveEvent;
            _manager.PrefabBullet = bulletConfig.Bullet;
            _manager.SpawnPoint = _weapon.GetActiveWeapon().Point;
            var _bullet = _poolSystem.ActivePool();

            _bullet.GetData<Speed>().Value = bulletConfig.Speed;
            _bullet.GetData<MoveDirection>().Value = _weapon.GetActiveWeapon().Point.forward;
            _bullet.GetData<LifeTime>().Value = bulletConfig.LifeTime;
            _bullet.GetData<Pool>().Value = this;
            _bullet.GetData<BulletEffects>().Value = bulletConfig.Effects;
            if (_bullet.TryGetData(out LifeTimerRequest data))
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