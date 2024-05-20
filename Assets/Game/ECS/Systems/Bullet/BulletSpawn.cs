using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using OtusProject.Component.Bullet;
using OtusProject.Component.Events;
using UnityEngine;

namespace OtusProject.System.Bullet
{
    internal sealed class BulletSpawn : IEcsRunSystem 
    {
        private readonly EcsFilterInject<Inc<BulletPrefab, BulletSpawnPoint, BulletPool, BulletSpeed, BulletDamage, BulletLife>> _filter;
        private readonly EcsCustomInject<EntityManager> _entityManager;
        private readonly EcsPoolInject<SpawnEvents> _bulletEvent;

        public void Run (IEcsSystems systems) {
            foreach(var entity in _filter.Value)
            {
                var bullet = _filter.Pools.Inc1.Get(entity).Value;
                var point = _filter.Pools.Inc2.Get(entity).Value;
                var pool = _filter.Pools.Inc3.Get(entity).Value;
                var damage = _filter.Pools.Inc5.Get(entity).Value;
                var speed = _filter.Pools.Inc4.Get(entity).Value;
                var life = _filter.Pools.Inc6.Get(entity).Value;

                if (_bulletEvent.Value.Has(entity))
                {
                    var newBullet = _entityManager.Value.Create(bullet, point.transform.position,
                        bullet.transform.rotation, pool);
                    newBullet.GetData<BulletDamage>().Value = damage;
                    newBullet.GetData<BulletSpeed>().Value = speed;
                    newBullet.GetData<BulletLife>().Value = life;
                    newBullet.GetData<MoveDirection>().Value = point.forward;
                }
            }
        }
    }
}