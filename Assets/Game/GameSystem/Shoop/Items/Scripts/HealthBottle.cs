using OtusProject.Player;
using System;
using UnityEngine;

namespace OtusProject.ItemSystem
{
    [Serializable]
    public class HealthBottle : IItems
    {
        [SerializeField] private int _health = 1;
        [SerializeField] public Sprite ItemIcon;
        private PlayerSetHealth _playerSetHealth;

        HealthBottle(PlayerSetHealth playerSetHealth)
        {
            _playerSetHealth = playerSetHealth;
            Debug.Log($"1 {_playerSetHealth}");
        }

        public void BuyItem()
        {
            Debug.Log($"Вылечились на {_health} {_playerSetHealth}");

            _playerSetHealth.SetHealth(_health);
        }

        public Sprite GetIcon()
        {
            return ItemIcon;
        }
    }
}
