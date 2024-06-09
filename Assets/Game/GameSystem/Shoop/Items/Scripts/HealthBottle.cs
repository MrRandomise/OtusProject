using Leopotam.EcsLite.Entities;
using OtusProject.Content;
using OtusProject.Player;
using System;
using UnityEngine;
using Zenject;

namespace OtusProject.ItemSystem
{
    [Serializable]
    public class HealthBottle : IItems
    {
        private static PlayerSetHealth _playerSetHealth;
        [SerializeField] private int _health = 1;
        [SerializeField] public Sprite ItemIcon;
        private Entity _character;

        [Inject]
        private void Construct(PlayerSetHealth playerSetHealth, CharacterInstaller entity)
        {
            _playerSetHealth = playerSetHealth;
            _character = entity.GetComponent<Entity>();
        }

        public void BuyItem()
        {
            _playerSetHealth.SetHealth(_health, _character);
            Debug.Log($"Вылечились на {_health}");
        }

        public Sprite GetIcon()
        {
            return ItemIcon;
        }
    }
}
