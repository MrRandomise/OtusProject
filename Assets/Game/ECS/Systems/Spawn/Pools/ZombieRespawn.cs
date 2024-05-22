using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Bullet;
using OtusProject.Component.Zombie;
using OtusProject.Component.Spawn;
using OtusProject.Component.Events;
using OtusProject.Component.Request;

namespace OtusProject.System.Pools
{
    sealed class ZombiesRespawn : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<InactiveTag, ZombieTransform, ZombieHealth, ZombieCurrHealth>> _filter;
        private readonly EcsFilterInject<Inc<SpawnActivePool, SpawnPoints>> _activePool;
        private readonly EcsPoolInject<ZombieAddPoolRequest> _respawnRequest;
        private readonly EcsPoolInject<InactiveTag> _inactiveTag;
        private readonly EcsPoolInject<DeadTag> _deadTag;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                if(_respawnRequest.Value.Has(entity))
                {
                    ref var zombieTransform = ref _filter.Pools.Inc2.Get(entity).Value;
                    ref var currHealth = ref _filter.Pools.Inc4.Get(entity);
                    var health = _filter.Pools.Inc3.Get(entity);
                    foreach (var poolEntity in _activePool.Value)
                    {
                        var index = UnityEngine.Random.Range(0, _activePool.Pools.Inc2.Get(poolEntity).Value.Count);
                        var point = _activePool.Pools.Inc2.Get(poolEntity).Value[index];
                        var ActivePool = _activePool.Pools.Inc1.Get(poolEntity);
                        _inactiveTag.Value.Del(entity);
                        _respawnRequest.Value.Del(entity);
                        _deadTag.Value.Del(entity);
                        currHealth.Value = health.Value;
                        zombieTransform.SetParent(ActivePool.Value);
                        zombieTransform.position = point.position;
                    }
                }
            }
        }
    }
}