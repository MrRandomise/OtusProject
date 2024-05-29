using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Request;
using OtusProject.Component.Zombie;
using UnityEngine;

namespace OtusProject.System.Zombie
{
    internal sealed class ZombieDropSystem : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<ZombieDrop, ZombiePosition>> _filter;
        private readonly EcsPoolInject<ZombieDropRequest> _dropRequest;
        public void Run (IEcsSystems systems) {
            var pref = _filter.Pools.Inc1;
            var pos = _filter.Pools.Inc2;
            foreach (var entity in _filter.Value)
            {
                if(_dropRequest.Value.Has(entity))
                {
                    GameObject.Instantiate(pref.Get(entity).Value, pos.Get(entity).Value, new Quaternion(pos.Get(entity).Value.x, 0, pos.Get(entity).Value.z, 0));
                    _dropRequest.Value.Del(entity);
                }
            }
        }
    }
}