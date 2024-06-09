using Leopotam.EcsLite.Entities;
using OtusProject.ECSEvent;
using UnityEngine;

namespace OtusProject.View
{
    public class KillZombieView
    {
        private OnDeathInECS _onDeathInECS;
        private ZombieView _zombieView;
        private int ZombiKilled = 0;

        KillZombieView(OnDeathInECS onDeathInECS, ZombieView zombieView)
        {
            _onDeathInECS = onDeathInECS;
            _zombieView = zombieView;
            _onDeathInECS.OnDeath += OnZombieDeath;
            SetZombieKilled(0);
        }

        private void OnZombieDeath(Entity res, Transform pos)
        {
            ZombiKilled++;
            _zombieView.Kills.text = $"x {ZombiKilled}";
        }


        public void SetZombieKilled(int zombieKilled)
        {
            ZombiKilled = zombieKilled;
        }
    }
}

