using Leopotam.EcsLite.Entities;
using OtusProject.ECSEvent;
using OtusProject.Pools;
using OtusProject.View;
using UnityEngine;


namespace OtusProject.Waves
{
    public sealed class WaveManager
    {
        private OnDeathInECS _onDeathInECS;
        private WaveSystem _waveSystem;
        private PoolZombieManager _poolZombieManager;
        private int _currentKillZombie = 0;

        WaveManager(OnDeathInECS onDeathInECS, WaveSystem waveSystem, PoolZombieManager poolZombieManager)
        {
            _onDeathInECS = onDeathInECS;
            _waveSystem = waveSystem;
            _onDeathInECS.OnDeath += EndWave;
            _poolZombieManager = poolZombieManager;
        }

        private void EndWave(Entity entity, Transform pos)
        {
            _currentKillZombie++;
            ref var total = ref _poolZombieManager.InitialCountZombie;
            if (entity.CompareTag("Zombie") && _currentKillZombie == total)
            {
                _currentKillZombie = 0;
                _waveSystem.Stop();
                total *= 2;
            }
        }
    }
}

