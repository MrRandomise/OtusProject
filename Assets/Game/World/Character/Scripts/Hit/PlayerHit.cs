using System;
using Zenject;
using UnityEngine;

namespace OtusProject.Player.Hit
{
    public sealed class PlayerHit : IDisposable
    {
        private HitEvents _hit;
        private Character _character;
        public event Action<int> OnSetHealth;

        [Inject]
        private void Construct(HitEvents hitCol, Character character)
        {
            _hit = hitCol;
            _hit.OnCollision += SetHealth;
            _character = character;
        }

        private void SetHealth()
        {
            _character.Health -= 1;
            OnSetHealth?.Invoke(_character.Health);
        }

        public void Dispose()
        {
            _hit.OnCollision -= SetHealth;
        }
    }
}