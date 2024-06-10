using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component;
using OtusProject.Component.Events;
using UnityEngine;

namespace OtusProject.Systems.View
{
    internal sealed class AnimatorDamageSystem : IEcsRunSystem 
    {
        private readonly EcsFilterInject<Inc<ObjectAnimator>> _filter;
        private readonly EcsPoolInject<DeathEvent> _deadRequest;
        private readonly EcsPoolInject<DamageEvent> _damageEvent;

        private readonly int _damage = Animator.StringToHash("Damage");

        public void Run(IEcsSystems systems)
        {
            var animatorPool = _filter.Pools.Inc1;
            foreach (var entity in _filter.Value)
            {
                if (_damageEvent.Value.Has(entity) && !_deadRequest.Value.Has(entity))
                {
                    animatorPool.Get(entity).Value.SetTrigger(_damage);
                }
            }
        }
    }
}