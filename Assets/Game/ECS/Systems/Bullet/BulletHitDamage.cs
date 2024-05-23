using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Events;

namespace OtusProject.System.Bullet
{
    internal sealed class BulletHitDamage : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<BulletHitEvent>> _filter;
        private readonly EcsPoolInject<DamageRequest> _damageRequest;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                _damageRequest.Value.Add(entity).Value = _filter.Pools.Inc1.Get(entity).Value;
            }
        }
    }
}