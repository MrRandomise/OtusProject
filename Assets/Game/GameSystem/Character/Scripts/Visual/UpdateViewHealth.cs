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

        [Inject]
        private void Construct(HealthView healthView)
        {
            HitEvents.OnHit += UpdateHealthView;
            _healthView = healthView;
        }

        private void UpdateHealthView(int health, Entity entity)
        {
            _healthView.Value.text = $"x {entity.GetData<CurrentHealth>().Value}";
        }
    }
}
