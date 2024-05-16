using System;
using Zenject;
using UnityEngine;

namespace OtusProject.Player.Death
{
    public sealed class DeathPlayer : IDisposable
    {
        public event Action OnDeath;
        private Character _character;

        [Inject]
        private void construct(Character character)
        {
            _character = character;
            _character.OnSetHealth += isDead;
        }

        private void isDead(int health)
        {
            if(health <= 0)
            {
                _character.CanMove = false;
                _character.IsAlive = false;
                OnDeath?.Invoke();
            }
        }

        public void Dispose()
        {
            _character.OnSetHealth -= isDead;
        }
    }
}
