using OtusProject.View;
using System;
namespace OtusProject.Player
{
    public class HealthPresenter : IDisposable
    {
        private HealthView _healthView;
        private PlayerHealth _playerSetHealth;

        HealthPresenter(HealthView healthView, PlayerHealth playerSetHealth, CharacterInstaller character)
        {
            _healthView = healthView;
            _playerSetHealth = playerSetHealth;
            UpdateHealthView(character.Health);
            _playerSetHealth.OnChangeHealth += UpdateHealthView;
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
