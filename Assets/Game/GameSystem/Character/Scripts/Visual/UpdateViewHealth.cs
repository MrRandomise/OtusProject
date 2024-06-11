using Leopotam.EcsLite.Entities;
using OtusProject.Component;
using OtusProject.Pools;
using OtusProject.View;
using OtusProject.Zombie.Hit;
using UnityEngine;
using Zenject;

namespace OtusProject.Player
{
    public class UpdateViewHealth
    {
        private HealthView _healthView;
        private Entity _entity;
        UpdateViewHealth(HealthView healthView, CharacterInstaller characterInstaller)
        {
            HitEvents.OnHit += UpdateHealthView;
            _healthView = healthView;
            _entity = characterInstaller.GetComponent<Entity>();
        }

        private void UpdateHealthView(int health)
        {
            _healthView.Value.text = $"x {_entity.GetData<CurrentHealth>().Value}";
        }
    }
}
