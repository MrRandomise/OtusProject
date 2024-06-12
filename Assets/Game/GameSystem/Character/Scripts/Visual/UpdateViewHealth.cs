using Leopotam.EcsLite.Entities;
using OtusProject.Component;
using OtusProject.View;
using System;
namespace OtusProject.Player
{
    public class UpdateViewHealth : IDisposable
    {
        private HealthView _healthView;
        private PlayerSetHealth _playerSetHealth;

        UpdateViewHealth(HealthView healthView, CharacterInstaller characterInstaller, PlayerSetHealth playerSetHealth)
        {
            _healthView = healthView;
            _playerSetHealth = playerSetHealth;
            _playerSetHealth.OnChangeHealth += UpdateHealthView;
            UpdateHealthView(characterInstaller.Health);
        }

        private void UpdateHealthView(int health)
        {
            _healthView.SetHealthView(health);
        }

        public void Dispose()
        {
            _playerSetHealth.OnChangeHealth -= UpdateHealthView;
        }
    }
}
