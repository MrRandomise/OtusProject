using OtusProject.Player;
using System;
using UnityEngine;
using Zenject;

namespace OtusProject.ItemSystem
{
    [Serializable]
    public class HealthBottle : IProduct
    {
        private static PlayerSetHealth _playerSetHealth;
        [SerializeField] private int _health = 1;
        [SerializeField] private Sprite ItemIcon;

        [Inject]
        private void Construct(PlayerSetHealth playerSetHealth)
        {
            _playerSetHealth = playerSetHealth;
        }

        public void BuyItem()
        {
            _playerSetHealth.SetHealth(_health);
        }

        public Sprite GetIcon()
        {
            return ItemIcon;
        }
    }
}
