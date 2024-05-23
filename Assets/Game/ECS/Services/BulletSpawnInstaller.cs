using Leopotam.EcsLite.Entities;
using OtusProject.Component.Bullet;
using OtusProject.Component.View;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;

namespace OtusProject.Content
{
    public class BulletSpawnInstaller : EntityInstaller
    {
        [SerializeField] private Transform _bulletPool;
        [SerializeField] private Transform _bulletInActivePool;

        protected override void Install(Entity entity)
        {
            entity.AddData(new BulletPrefab ());
            entity.AddData(new BulletDamage ());
            entity.AddData(new BulletSpeed ());
            entity.AddData(new BulletLife ());
            entity.AddData(new BulletActivePool { Value = _bulletPool });
            entity.AddData(new BulletInActivePool { Value = _bulletInActivePool });
            entity.AddData(new BulletSpawnPoint { });
        }

        protected override void Dispose(Entity entity)
        {

        }
    }
}