using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Bullet;
using OtusProject.Component.Events;
using OtusProject.Component.Zombie;
using UnityEngine;


namespace OtusProject.System.Zombie
{
    internal class ZmbieHealthBar : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<ZombieHealth>> _filter;
        private readonly EcsFilterInject<Inc<InactiveTag>> _respawnFilter;
        private readonly EcsPoolInject<HealthBar> _healthBarLine;
        private readonly EcsPoolInject<ZombieCurrHealth> _healthCurrentPool;
        private readonly EcsPoolInject<ZombieHealth> _health;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _respawnFilter.Value) 
            {
                if (_health.Value.Has(entity))
                {
                    if (_healthCurrentPool.Value.Get(entity).Value != _health.Value.Get(entity).Value)
                    {
                        _healthBarLine.Value.Get(entity).Value.localScale = new Vector3(1, 1, 1);
                    }
                }
            }

            foreach (var entity in _filter.Value)
            {
                if (_health.Value.Has(entity))
                {
                    var h = (float)_healthCurrentPool.Value.Get(entity).Value / _health.Value.Get(entity).Value;

                    if (h <= 0)
                    {
                        h = 0;
                    }
                    _healthBarLine.Value.Get(entity).Value.localScale = new Vector3(h, 1, 1);
                }
            }
        }
    }
}