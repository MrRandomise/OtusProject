using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component;
using UnityEngine;

namespace OtusProject.System.Zombie
{
    internal sealed class RotateCharacterSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<Speed, CurrentTransform, MoveDirection, CharacterTag, MousePosition, MainCamera>, Exc<InactiveTag, DeadTag>> _filter;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var mousePosition = Input.mousePosition;
                ref var position = ref _filter.Pools.Inc2.Get(entity);
                ref var moveDirection = ref _filter.Pools.Inc3.Get(entity);
                var previousMousePosition = _filter.Pools.Inc5.Get(entity);
                var camera = _filter.Pools.Inc6.Get(entity);
                if (mousePosition != previousMousePosition.Value)
                {
                    if (Physics.Raycast(camera.Value.ScreenPointToRay(Input.mousePosition), out var hit))
                    {
                        position.Value.LookAt(new Vector3(hit.point.x, position.Value.position.y, hit.point.z));
                        previousMousePosition.Value = mousePosition;
                    }
                }
            }
        }
    }
}