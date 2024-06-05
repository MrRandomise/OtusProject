using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Bullet;
using OtusProject.Component.Events;
using UnityEngine;
using OtusProject.Component;

namespace OtusProject.System.Bullet
{
    internal sealed class HitSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<CurrentTransform, BulletEffects, BulletTag>, Exc<InactiveTag>> _filter;
        private readonly EcsFilterInject<Inc<ZombieTag, CurrentTransform>> _targetFilter;
        private readonly EcsPoolInject<HitEvent> _bulletHit;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var bulletPos = _filter.Pools.Inc1.Get(entity).Value;
                bulletPos.position = new Vector3(bulletPos.position.x, 0, bulletPos.position.z);
                foreach (var target in _targetFilter.Value)
                {
                    if (Vector3.Distance(_targetFilter.Pools.Inc2.Get(target).Value.position, bulletPos.position) < 1.5f)
                    {
                        _bulletHit.Value.Add(target).Value = _filter.Pools.Inc2.Get(entity).Value;
                    }
                }
            }
        }
    }
}