using System;
using Zenject;

namespace OtusProject.Player.Death
{
    public sealed class DeathPlayer : IDisposable
    {
        public event Action OnDeath;
        private PlayerSetHealth _setHealth;
        private Character _character;

        [Inject]
        private void construct(Character character, PlayerSetHealth playerHit)
        {
            _setHealth = playerHit;
            _character = character;
            _setHealth.OnSetHealth += isDead;
        }

        private void isDead()
        {
            if(_character.Health <= 0)
            {
                _character.CanMove = false;
                _character.IsAlive = false;
                OnDeath?.Invoke();
                _setHealth.OnSetHealth -= isDead;
            }
        }

        public void Dispose()
        {
            _setHealth.OnSetHealth -= isDead;
        }
    }
}
