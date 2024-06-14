using OtusProject.Player;
using System;
using UnityEngine;
using Zenject;

namespace OtusProject.ItemSystem
{
    [Serializable]
    public class HealthBottleBuyer : IProduct
    {
        private static PlayerHealth _playerSetHealth;
        [SerializeField] private int _health = 1;

        [Inject]
        private void Construct(PlayerHealth playerSetHealth)
        {
            _playerSetHealth = playerSetHealth;
        }

        public void BuyProduct()
        {
            _playerSetHealth.SetHealth(_health);
        }
    }
}
