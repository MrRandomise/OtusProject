using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Events;
using OtusProject.Component.Zombie;
using UnityEngine;

namespace OtusProject.Systems.View
{
    sealed class AnimatorViewSystem : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<ZombieAnimator>> _filter;
        private readonly EcsPoolInject<ZombieMoveEvent> _moveEvent;
        private readonly int _move = Animator.StringToHash("Move");
        public void Run(IEcsSystems systems)
        {
            var animatorPool = _filter.Pools.Inc1;
            foreach (var entity in _filter.Value)
            {
                if (_moveEvent.Value.Has(entity))
                {
                    animatorPool.Get(entity).Value.SetBool(_move, true);
                }
            }
        }
    }
}