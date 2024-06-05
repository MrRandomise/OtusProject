using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component;
using OtusProject.Component.Request;
using UnityEngine;

namespace OtusProject.System.Zombie
{
    internal sealed class DropSystem : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<Drops, CurrentTransform, ZombieTag>> _filter;
        private readonly EcsPoolInject<DropRequest> _dropRequest;
        public void Run (IEcsSystems systems) {
            var pref = _filter.Pools.Inc1;
            var pos = _filter.Pools.Inc2;
            foreach (var entity in _filter.Value)
            {
                if(_dropRequest.Value.Has(entity))
                {
                    Object.Instantiate(pref.Get(entity).Value, pos.Get(entity).Value.position, new Quaternion(pos.Get(entity).Value.rotation.x, 0, pos.Get(entity).Value.rotation.z, 0));
                    _dropRequest.Value.Del(entity);
                }
            }
        }
    }
}