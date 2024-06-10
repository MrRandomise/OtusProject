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
        private KillZombieManager _killZombieManager;
        private PoolZombieManager _poolZombieManager;
        WaveManager(OnDeathInECS onDeathInECS, WaveSystem waveSystem, KillZombieManager killZombieManager, PoolZombieManager poolZombieManager)
        {
            _onDeathInECS = onDeathInECS;
            _waveSystem = waveSystem;
            _onDeathInECS.OnDeath += EndWave;
            _killZombieManager = killZombieManager;
            _poolZombieManager = poolZombieManager;
        }

        private void EndWave(Entity entity, Transform pos)
        {
            var Kill = _killZombieManager.GetZombieKilled();
            var total = _poolZombieManager.InitialCountZombie;
            if (entity.CompareTag("Zombie") && Kill == total / 2)
            {
                _waveSystem.Stop();
            }
        }
    }
}

