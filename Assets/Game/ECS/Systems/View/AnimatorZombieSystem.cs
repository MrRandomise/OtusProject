using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Zombie;
using OtusProject.Component.Request;
using UnityEngine;

namespace OtusProject.Systems.View
{
    sealed class AnimatorZombieSystem : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<ZombieAnimator>> _filter;
        private readonly EcsPoolInject<ZombieMoveRequest> _moveRequest;
        private readonly EcsPoolInject<ZombieAttackRequest> _attackRequest;
        private readonly int _move = Animator.StringToHash("Move");
        private readonly int _attack = Animator.StringToHash("Attack");
        public void Run(IEcsSystems systems)
        {
            var animatorPool = _filter.Pools.Inc1;
            foreach (var entity in _filter.Value)
            {
                if (_moveRequest.Value.Has(entity))
                {
                    animatorPool.Get(entity).Value.SetBool(_move, true);
                    animatorPool.Get(entity).Value.SetBool(_attack, false);
                    _moveRequest.Value.Del(entity);
                }
                if (_attackRequest.Value.Has(entity))
                {
                    animatorPool.Get(entity).Value.SetBool(_attack, true);
                    animatorPool.Get(entity).Value.SetBool(_move, false);
                    _attackRequest.Value.Del(entity);
                }
            }
        }
    }
}