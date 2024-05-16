using System;
using Zenject;
using UnityEngine;

namespace OtusProject.Player.Hit
{
    public sealed class Hit : IDisposable
    {
        private HitEvents _hit;
        private Character _character;

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
        }

        public void Dispose()
        {
            _hit.OnCollision -= SetHealth;
        }
    }
}