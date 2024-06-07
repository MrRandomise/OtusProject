using OtusProject.Player.Death;
using System;
using Zenject;
using OtusProject.Content;
using Leopotam.EcsLite.Entities;
using OtusProject.Component.Events;

namespace OtusProject.GameOver
{
    public sealed class GameOverSystem : IDisposable
    {
        //private DeathPlayer _deathPlayer;
        //private GameOverMenu _gameOverMenu;
        //private Entity _spawn;

        //[Inject]
        //private void construct(DeathPlayer deathPlayer, GameOverMenu gameOverMenu, SpawnInstaller spawn)
        //{
        //    _deathPlayer = deathPlayer;
        //    _spawn = spawn.GetComponent<Entity>();
        //    _deathPlayer.OnDeath += StopGame;
        //    _gameOverMenu = gameOverMenu;
        //}

        //private void StopGame()
        //{
        //    _gameOverMenu.Menu.SetActive(true);
        //    _spawn.SetData(new GameOverEvent());
        //}

        public void Dispose()
        {
        //    _deathPlayer.OnDeath -= StopGame;
        }
    }
}

