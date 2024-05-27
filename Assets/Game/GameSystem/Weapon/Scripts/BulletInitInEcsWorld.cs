using System;
using Leopotam.EcsLite.Entities;
using OtusProject.Component.Bullet;
using OtusProject.Component.Events;
using OtusProject.Content;
using OtusProject.Weapons;
using Zenject;

namespace OtusProject.Config.Weapons
{
    public sealed class BulletInitInEcsWorld
    {
        public event Action OnBulletEvent;
        private Entity _entity;

        [Inject]
        private void Contruct(BulletSpawnInstaller entity)
        {
            _entity = entity.GetComponent<Entity>();
        }

        public void BulletInitial(IWeapon weapon)
        {
            var bulletConfig = weapon.GetBulletConfig();
            _entity.GetData<BulletPrefab>().Value = bulletConfig.Bullet;
            _entity.GetData<BulletSpeed>().Value = bulletConfig.Speed;
            _entity.GetData<BulletLife>().Value = bulletConfig.LifeTime;
            _entity.GetData<BulletSpawnPoint>().Value = weapon.GetBulletPoint();
            _entity.SetData(new SpawnEvents());
            _entity.SetData(new BulletEffects { Value = bulletConfig.Effects });
            OnBulletEvent?.Invoke();
        }
    }
}