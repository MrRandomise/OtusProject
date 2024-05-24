using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Bullet;
using OtusProject.Component.Zombie;
using OtusProject.Component.Events;
using UnityEngine;
using OtusProject.Component.Request;

namespace OtusProject.System.Bullet
{
    internal sealed class BulletHit : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<BulletPosition, BulletDamage>, Exc<BulletInactiveTag>> _filter;
        private readonly EcsFilterInject<Inc<ZombiePosition>> _targetFilter;
        private readonly EcsPoolInject<BulletHitEvent> _bulletHit;
        private readonly EcsPoolInject<BulletAddPoolRequest> _poolRequest;

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
                        _bulletHit.Value.Add(target).Value = _filter.Pools.Inc2.Get(entity).Value;
                        _poolRequest.Value.Add(entity);
                    }
                }
            }
        }
    }
}