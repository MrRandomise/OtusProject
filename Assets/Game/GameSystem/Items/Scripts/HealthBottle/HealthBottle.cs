using OtusProject.Player;
using System;
using UnityEngine;
using Zenject;

namespace OtusProject.ItemSystem
{
    
    public class HealthBottle : IItems
    {
        private PlayerSetHealth _playerSetHealth;
        private int _health = 1;

        [Inject]
        private void Construct(PlayerSetHealth playerSetHealth)
        {
            _playerSetHealth = playerSetHealth;
        }

        public void UseItem()
        {
            _playerSetHealth.SetHealth(_health);
        }
    }
}
