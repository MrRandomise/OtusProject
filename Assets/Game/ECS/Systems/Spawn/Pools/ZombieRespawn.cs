using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Bullet;
using OtusProject.Component.Zombie;
using OtusProject.Component.Spawn;
using OtusProject.Component.Events;
using OtusProject.Component.Request;
using UnityEditor.PackageManager.Requests;

namespace OtusProject.System.Pools
{
    sealed class ZombiesRespawn : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<InactiveTag, ZombieTransform, ZombiePosition>> _filter;
        private readonly EcsFilterInject<Inc<SpawnActivePool, SpawnPoints>> _activePool;
        private readonly EcsPoolInject<RespawnEvent> _respawnRequest;
        private readonly EcsPoolInject<InactiveTag> _inactiveTag;
        private readonly EcsPoolInject<DeadTag> _deadTag;
        private readonly EcsPoolInject<DeathEvent> _deadRequest;
        private readonly EcsPoolInject<MoveEvent> _moveRequest;
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                if(_respawnRequest.Value.Has(entity))
                {
                    ref var zombieTransform = ref _filter.Pools.Inc2.Get(entity).Value;
                    ref var position = ref _filter.Pools.Inc3.Get(entity);
                    foreach (var pool in _activePool.Value)
                    {
                        var index = UnityEngine.Random.Range(0, _activePool.Pools.Inc2.Get(entity).Value.Count);
                        var point = _activePool.Pools.Inc2.Get(entity).Value[index];
                        var ActivePool = _activePool.Pools.Inc1.Get(pool);
                        zombieTransform.SetParent(ActivePool.Value);
                        position.Value = point.position;
                        _inactiveTag.Value.Del(entity);
                        _respawnRequest.Value.Del(entity);
                        _deadRequest.Value.Del(entity);
                        _deadTag.Value.Del(entity);
                        _moveRequest.Value.Add(entity);
                    }
                }
            }
        }
    }
}