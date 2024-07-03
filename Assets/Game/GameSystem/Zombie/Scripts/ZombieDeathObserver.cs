using Leopotam.EcsLite.Entities;
using OtusProject.ECSEvent;
using OtusProject.Pools;
using UnityEngine;


namespace OtusProject.Waves
{
    public sealed class ZombieDeathObserver
    {
        private OnDeathInECS _onDeathInECS;
        private WaveSystem _waveSystem;
        private PoolZombieManager _poolZombieManager;
        private int _currentKillZombie = 0;

        ZombieDeathObserver(OnDeathInECS onDeathInECS, WaveSystem waveSystem, PoolZombieManager poolZombieManager)
        {
            _onDeathInECS = onDeathInECS;
            _waveSystem = waveSystem;
            _onDeathInECS.OnDeath += ZombieDeath;
            _poolZombieManager = poolZombieManager;
        }

        private void ZombieDeath(Entity entity, Transform pos)
        {
            _currentKillZombie++;
            ref var total = ref _poolZombieManager.InitialCountZombie;
            if (entity.CompareTag("Zombie") && _currentKillZombie == total)
            {
                _currentKillZombie = 0;
                _waveSystem.StopTimeOutWave();
                total *= 2;
            }
        }
    }
}

