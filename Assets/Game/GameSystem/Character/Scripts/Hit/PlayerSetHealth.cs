using OtusProject.Zombie.Hit;
using System;
using Zenject;

namespace OtusProject.Player
{
    public sealed class PlayerSetHealth: IDisposable
    {
        public event Action OnSetHealth;
        private Character _character;

        [Inject]
        private void Construct(Character character)
        {
            _character = character;
            HitEvents.OnHit += SetHealth;
        }

        public void SetHealth(int damage)
        {
            _character.Health += damage;
            OnSetHealth?.Invoke();
        }

        public void Dispose()
        {
            HitEvents.OnHit -= SetHealth;
        }
    }
}