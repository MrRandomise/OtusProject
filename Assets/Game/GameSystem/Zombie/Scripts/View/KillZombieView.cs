using Leopotam.EcsLite.Entities;
using OtusProject.ECSEvent;
using UnityEngine;

namespace OtusProject.View
{
    public class KillZombieView
    {
        private OnDeathInECS _onDeathInECS;
        private ZombieView _zombieView;
        private KillZombieManager _killZombieManager;

        KillZombieView(OnDeathInECS onDeathInECS, ZombieView zombieView, KillZombieManager killZombieManager)
        {
            _onDeathInECS = onDeathInECS;
            _zombieView = zombieView;
            _onDeathInECS.OnDeath += OnZombieDeath;
            _killZombieManager = killZombieManager;
        }

        private void OnZombieDeath(Entity entity, Transform pos)
        {
            if (entity.CompareTag("Zombie"))
            {
                var count = _killZombieManager.GetZombieKilled();
                _zombieView.Kills.text = $"x {count}";
            }
        }
    }
}

