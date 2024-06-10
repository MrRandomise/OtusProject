using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component;
using UnityEngine;

namespace OtusProject.Systems.View
{
    internal sealed class AnimatorMoveSystem : IEcsRunSystem 
    {
        private readonly EcsFilterInject<Inc<ObjectAnimator, MoveDirection>> _filter;

        private readonly int _move = Animator.StringToHash("Move");

        public void Run(IEcsSystems systems)
        {
            var animatorPool = _filter.Pools.Inc1;
            foreach (var entity in _filter.Value)
            {
                if (_filter.Pools.Inc2.Get(entity).Value != Vector3.zero)
                {
                    animatorPool.Get(entity).Value.SetBool(_move, true);
                }
                else
                {
                    animatorPool.Get(entity).Value.SetBool(_move, false);
                }
            }
        }
    }
}