using Leopotam.EcsLite.Entities;
using OtusProject.Component;
using OtusProject.View;
using OtusProject.Zombie.Hit;
using System;
using Zenject;

namespace OtusProject.Player
{
    public sealed class PlayerSetHealth: IDisposable
    {
        private HealthView _healthView;
        private CharacterInstaller _characterInstaller;
        [Inject]
        private void Construct(HealthView healthView, CharacterInstaller character)
        {
            HitEvents.OnHit += SetHealth;
            _healthView = healthView;
            _characterInstaller = character;
            UpdateHealthView(_characterInstaller.Health);
        }

        public void SetHealth(int damage, Entity entity)
        {
            entity.GetData<CurrentHealth>().Value += damage;
            if(entity.GetData<CurrentHealth>().Value <= 0)
            {
                _characterInstaller.CanMove = false;
                _characterInstaller.IsAlive = false;
            }
        }

        private void UpdateHealthView(int health)
        {
            _healthView.Value.text = $"x {health}";
        }

        public void Dispose()
        {
            HitEvents.OnHit -= SetHealth;
        }
    }
}