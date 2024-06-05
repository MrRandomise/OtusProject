using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Zombie;
using OtusProject.Component.Events;
using UnityEngine;

namespace OtusProject.Systems.View
{
    internal sealed class AnimatorZombieSystem : IEcsRunSystem 
    {
        private readonly EcsFilterInject<Inc<ZombieAnimator>> _filter;
        private readonly EcsPoolInject<MoveEvent> _moveRequest;
        private readonly EcsPoolInject<AttackEvent> _attackRequest;
        private readonly EcsPoolInject<DeathEvent> _deadRequest;
        
        private readonly int _move = Animator.StringToHash("Move");
        private readonly int _stop = Animator.StringToHash("Stop");
        private readonly int _attack = Animator.StringToHash("Attack");
        private readonly int _death = Animator.StringToHash("Death");
        public void Run(IEcsSystems systems)
        {
            var animatorPool = _filter.Pools.Inc1;
            foreach (var entity in _filter.Value)
            {
                if (_moveRequest.Value.Has(entity))
                {
                    animatorPool.Get(entity).Value.SetBool(_move, true);
                    animatorPool.Get(entity).Value.SetBool(_attack, false);
                }
                if (_attackRequest.Value.Has(entity))
                {
                    animatorPool.Get(entity).Value.SetBool(_attack, true);
                    animatorPool.Get(entity).Value.SetBool(_move, false);
                }
                if(_deadRequest.Value.Has(entity))
                {
                    animatorPool.Get(entity).Value.SetBool(_attack, false);
                    animatorPool.Get(entity).Value.SetBool(_move, false);
                    animatorPool.Get(entity).Value.SetTrigger(_death);
                }
            }
        }
    }
}