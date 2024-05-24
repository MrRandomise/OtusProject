using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Events;
using OtusProject.Component.Zombie;

namespace OtusProject.System.Zombie
{
    internal sealed class ZombieTakeDamage : IEcsRunSystem 
    {
        
        private readonly EcsFilterInject<Inc<DamageEvent>> _filter;
        private readonly EcsPoolInject<ZombieCurrHealth> _health;

        public void Run (IEcsSystems systems) {
            var damage = _filter.Pools.Inc1;
            foreach (var entity in _filter.Value)
            {
                if (_health.Value.Has(entity))
                {
                    _health.Value.Get(entity).Value -= damage.Get(entity).Value;
                }
            }
        }
    }
}