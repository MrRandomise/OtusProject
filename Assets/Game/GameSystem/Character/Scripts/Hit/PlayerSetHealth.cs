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
        private CharacterInstaller _characterInstaller;
        private Entity _entity;
        public event Action<int> OnChangeHealth;

        [Inject]
        private void Construct(HealthView healthView, CharacterInstaller character)
        {
            HitZombieInTarget.OnHit += SetHealth;
            _characterInstaller = character;
            _entity = _characterInstaller.GetComponent<Entity>();
        }

        public void SetHealth(int health)
        {
            _entity.GetData<CurrentHealth>().Value += health;
            OnChangeHealth?.Invoke(_entity.GetData<CurrentHealth>().Value);
            if (_entity.GetData<CurrentHealth>().Value <= 0)
            {
                _characterInstaller.CanMove = false;
                _characterInstaller.IsAlive = false;
            }
        }

        public void Dispose()
        {
            HitZombieInTarget.OnHit -= SetHealth;
        }
    }
}