using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component;
using OtusProject.Component.Events;
using UnityEngine;

namespace OtusProject.Systems.View
{
    internal sealed class AnimatorEndWaveSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<EndWaveEvent, ObjectAnimator>> _filter;

        private readonly int _endWave = Animator.StringToHash("EndWave");

        public void Run(IEcsSystems systems)
        {
            var animatorPool = _filter.Pools.Inc2;
            foreach (var entity in _filter.Value)
            {
                animatorPool.Get(entity).Value.SetTrigger(_endWave);
            }
        }
    }
}