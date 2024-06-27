using Leopotam.EcsLite.Entities;
using OtusProject.ECSEvent;
using UnityEngine;

namespace OtusProject.View
{
    public class KillZombiePresenter
    {
        private OnDeathInECS _onDeathInECS;
        private KillsView _zombieView;
        private int _zombiKilled = 0;

        KillZombiePresenter(OnDeathInECS onDeathInECS, KillsView zombieView)
        {
            _onDeathInECS = onDeathInECS;
            _zombieView = zombieView;
            _onDeathInECS.OnDeath += OnZombieDeath;
            _zombiKilled = 0;
        }

        private void OnZombieDeath(Entity entity, Transform pos)
        {
            if (entity.CompareTag("Zombie"))
            {
                _zombiKilled++;
                _zombieView.SetKillView(_zombiKilled);
            }
        }
    }
}

