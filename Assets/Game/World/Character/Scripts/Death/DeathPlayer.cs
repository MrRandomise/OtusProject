using System;
using Zenject;
using OtusProject.Player.Hit;

namespace OtusProject.Player.Death
{
    public sealed class DeathPlayer : IDisposable
    {
        public event Action OnDeath;
        private PlayerHit _playerHit;
        private Character _character;

        [Inject]
        private void construct(Character character, PlayerHit playerHit)
        {
            _playerHit = playerHit;
            _character = character;
            _playerHit.OnSetHealth += isDead;
        }

        private void isDead(int health)
        {
            if(health <= 0)
            {
                _character.CanMove = false;
                _character.IsAlive = false;
                OnDeath?.Invoke();
                _playerHit.OnSetHealth -= isDead;
            }
        }

        public void Dispose()
        {
            _playerHit.OnSetHealth -= isDead;
        }
    }
}
