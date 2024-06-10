using Leopotam.EcsLite.Entities;
using OtusProject.ECSEvent;
using UnityEngine;
namespace OtusProject.View
{
    public class KillZombieManager
    {
        private OnDeathInECS _onDeathInECS;
        private int _zombiKilled = 0;

        KillZombieManager(OnDeathInECS onDeathInECS)
        {
            _onDeathInECS = onDeathInECS;
            _onDeathInECS.OnDeath += OnZombieDeath;
            SetZombieKilled(0);
        }

        private void OnZombieDeath(Entity entity, Transform pos)
        {
            if (entity.CompareTag("Zombie"))
            {
                _zombiKilled++;
            }
        }

        public void SetZombieKilled(int zombieKilled) => _zombiKilled = zombieKilled;
        public int GetZombieKilled() => _zombiKilled;
    }
}