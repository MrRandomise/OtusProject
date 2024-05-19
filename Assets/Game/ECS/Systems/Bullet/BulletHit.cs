using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Bullet;
using OtusProject.Component.Zombie;
using OtusProject.Component.Events;
using UnityEngine;

namespace OtusProject.System.Bullet
{
    internal sealed class BulletHit : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<BulletPosition, BulletDamage>> _filter;
        private readonly EcsFilterInject<Inc<ZombiePosition>> _targetFilter;
        private readonly EcsPoolInject<DamageRequest> _damageRequest;
        //private readonly EcsPoolInject<BulletRemovePoolRequest> _bulletRemoveRequest;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var bulletPos = _filter.Pools.Inc1.Get(entity).Value;
                bulletPos.y = 0;
                foreach (var target in _targetFilter.Value)
                {
                    if (Vector3.Distance(_targetFilter.Pools.Inc1.Get(target).Value, bulletPos) < 0.5f)
                    {
                        _damageRequest.Value.Add(target).Value = _filter.Pools.Inc2.Get(entity).Value;
                        //if (!_bulletRemoveRequest.Value.Has(target))
                        //{
                        //    _bulletRemoveRequest.Value.Add(entity);
                        //}
                    }
                }
            }
        }
    }
}