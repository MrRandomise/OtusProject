using OtusProject.Player;
using OtusProject.View;
using System;
using Zenject;

namespace OtusProject.Visual
{
    public sealed class HealthUpdate : IDisposable
    {
        private Character _character;
        private HealthView _health;
        private PlayerSetHealth _setHealth;

        [Inject]
        private void Construct(Character character, HealthView health, PlayerSetHealth setHealth)
        {
            _character = character;
            _health = health;
            _setHealth = setHealth;
            _setHealth.OnSetHealth += Update;
            Update();
        }

        private void Update()
        {
            _health.Value.text = $"x {_character.Health.ToString()}";
        }

        public void Dispose()
        {
            _setHealth.OnSetHealth -= Update;
        }
    }
}