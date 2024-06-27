using System;
using OtusProject.Player;

namespace OtusProject.GameOver
{
    public sealed class CharacterDeathObserver : IDisposable
    {
        private PlayerHealth _health;
        private GameOverMenu _gameOverMenu;

        CharacterDeathObserver(PlayerHealth health, GameOverMenu gameOverMenu)
        {
            _health = health;
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

