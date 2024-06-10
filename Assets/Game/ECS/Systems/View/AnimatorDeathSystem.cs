using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component;
using OtusProject.Component.Events;
using UnityEngine;

namespace OtusProject.Systems.View
{
    internal sealed class AnimatorDeathSystem : IEcsRunSystem 
    {
        private readonly EcsFilterInject<Inc<ObjectAnimator>> _filter;
        private readonly EcsPoolInject<DeathEvent> _deadRequest;

        private readonly int _move = Animator.StringToHash("Move");
        private readonly int _attack = Animator.StringToHash("Attack");
        private readonly int _death = Animator.StringToHash("Death");

        public void Run(IEcsSystems systems)
        {
            var animatorPool = _filter.Pools.Inc1;
            foreach (var entity in _filter.Value)
            {
                if (_deadRequest.Value.Has(entity))
                {
                    animatorPool.Get(entity).Value.SetBool(_attack, false);
                    animatorPool.Get(entity).Value.SetBool(_move, false);
                    animatorPool.Get(entity).Value.SetTrigger(_death);
                }
            }
        }
    }
}