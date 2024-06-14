using System;
using Zenject;
using Leopotam.EcsLite.Entities;
using OtusProject.Player;

namespace OtusProject.GameOver
{
    public sealed class GameOverSystem : IDisposable
    {
        private PlayerHealth _health;
        private GameOverMenu _gameOverMenu;

        [Inject]
        private void construct(PlayerHealth helaht, GameOverMenu gameOverMenu)
        {
            _health = helaht;
            _health.OnChangeHealth += StopGame;
            _gameOverMenu = gameOverMenu;
        }

        private void StopGame(int health)
        {
            if(health <= 0)
            {
                _gameOverMenu.Menu.SetActive(true);
            }
        }

        public void Dispose()
        {
            _health.OnChangeHealth -= StopGame;
        }
    }
}

