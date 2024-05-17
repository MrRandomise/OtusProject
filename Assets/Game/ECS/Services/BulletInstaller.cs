using Leopotam.EcsLite.Entities;
using OtusProject.BulletSystem;
using OtusProject.Component.Bullet;
using UnityEngine;

namespace OtusProject.Content
{
    public sealed class BulletInstaller : EntityInstaller
    {
        [SerializeField] private BulletData _bulletData;
        protected override void Install(Entity entity)
        {
            entity.AddData(new BulletDamage { Value = _bulletData.BulletConfig.Damage });
            entity.AddData(new BulletSpeed { Value = _bulletData.BulletConfig.Speed });
            entity.AddData(new BulletLife { Value = _bulletData.BulletConfig.LifeTime });
            entity.AddData(new BulletPool { Value = _bulletData.BulletPool });
            entity.AddData(new Position { Value = transform.position });
            entity.AddData(new MoveDirection { Value = Vector3.zero });
        }

        protected override void Dispose(Entity entity)
        {

        }
    }
}