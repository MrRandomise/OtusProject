using System;
using Leopotam.EcsLite.Entities;
using OtusProject.Component.Bullet;
using OtusProject.Component.Events;
using OtusProject.Content;
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

        public void BulletInitial(Weapon weapon)
        {
            var bulletConfig = weapon.BulletConfig;
            _entity.GetData<BulletPrefab>().Value = bulletConfig.Bullet;
            _entity.GetData<BulletDamage>().Value = bulletConfig.Damage;
            _entity.GetData<BulletSpeed>().Value = bulletConfig.Speed;
            _entity.GetData<BulletLife>().Value = bulletConfig.LifeTime;
            _entity.GetData<BulletSpawnPoint>().Value = weapon.BulletPoint;
            _entity.SetData(new SpawnEvents());
            OnBulletEvent?.Invoke();
        }
    }
}