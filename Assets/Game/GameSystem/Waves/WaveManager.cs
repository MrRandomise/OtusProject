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
        private EndWave _endWave;
        private PoolZombieManager _poolZombieManager;
        private int _currentKillZombie = 0;

        WaveManager(OnDeathInECS onDeathInECS, EndWave endWave, PoolZombieManager poolZombieManager)
        {
            _onDeathInECS = onDeathInECS;
            _endWave = endWave;
            _onDeathInECS.OnDeath += PlayerDeath;
            _poolZombieManager = poolZombieManager;
        }

        private void PlayerDeath(Entity entity, Transform pos)
        {
            _currentKillZombie++;
            ref var total = ref _poolZombieManager.InitialCountZombie;
            if (entity.CompareTag("Zombie") && _currentKillZombie == total)
            {
                _currentKillZombie = 0;
                _endWave.StartTimer();
                total *= 2;
            }
        }
    }
}

