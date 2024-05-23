using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusProject.Component.Zombie;
using OtusProject.Component.Request;
using OtusProject.Component.Spawn;
using OtusProject.Component.Events;

namespace OtusProject.System.Spawn
{

    internal sealed class ZombieEndWave : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<ZombieDeathRequest>> _filter;
        private readonly EcsFilterInject<Inc<ZombieCurrCount, SpawnWave, SpawnCountZombie>> _filterInstal;
        private readonly EcsPoolInject<ZombieDeathRequest> _zombieRequest;
        private readonly EcsPoolInject<BuyMenuRequest> _buyMenuRequest;
        private readonly int _minCountZombie = 1;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                foreach (var installer in _filterInstal.Value)
                {
                    _filterInstal.Pools.Inc1.Get(installer).Value--;
                    if(_filterInstal.Pools.Inc1.Get(installer).Value == 0)
                    {
                        _filterInstal.Pools.Inc2.Get(installer).Value++;
                        if (_filterInstal.Pools.Inc3.Get(installer).Value == _minCountZombie)
                        {
                            _filterInstal.Pools.Inc3.Get(installer).Value++;
                        }
                        else
                        {
                            _filterInstal.Pools.Inc3.Get(installer).Value *= _filterInstal.Pools.Inc3.Get(installer).Value;
                        }
                        _buyMenuRequest.Value.Add(installer);
                    }
                    _zombieRequest.Value.Del(entity);
                }
            }
        }
    }
}