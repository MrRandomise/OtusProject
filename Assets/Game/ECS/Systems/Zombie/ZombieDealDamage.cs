using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Zombie;
namespace OtusProject.System.Zombie
{
    sealed class ZombieDealDamage : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<DamageRequest, ZombieCurrHealth>> _filter;
        private readonly EcsPoolInject<DamageRequest> _damageRequest;
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                ref var health = ref  _filter.Pools.Inc2.Get(entity).Value;
                var damage = _filter.Pools.Inc1.Get(entity).Value;
                health -= damage;
                _damageRequest.Value.Del(entity);
            }
        }
    }
}