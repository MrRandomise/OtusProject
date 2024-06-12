using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component;
using OtusProject.Component.Events;
using UnityEngine;

namespace OtusProject.Systems.View
{
    internal sealed class AnimatorAttackSystem : IEcsRunSystem 
    {
        private readonly EcsFilterInject<Inc<ObjectAnimator>> _filter;
        private readonly EcsPoolInject<AttackEvent> _attackRequest;

        private readonly int _attack = Animator.StringToHash("Attack");

        public void Run(IEcsSystems systems)
        {
            var animatorPool = _filter.Pools.Inc1;
            foreach (var entity in _filter.Value)
            {
                if (_attackRequest.Value.Has(entity))
                {
                    animatorPool.Get(entity).Value.SetBool(_attack, true);
                }
                if (!_attackRequest.Value.Has(entity) && animatorPool.Get(entity).Value.GetBool(_attack))
                {
                    animatorPool.Get(entity).Value.SetBool(_attack, false);
                }
            }
        }
    }
}