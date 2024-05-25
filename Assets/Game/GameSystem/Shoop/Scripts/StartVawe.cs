using System;
using OtusProject.Content;
using UnityEngine.UI;
using Zenject;
using Leopotam.EcsLite.Entities;
using OtusProject.Component.Request;
using UnityEngine;
using OtusProject.Player;
using OtusProject.Config.Map;

namespace OtusProject.View
{
    public sealed class StartVawe : IDisposable
    {
        private Button _startButton;
        private Entity _spawnInstaller;
        private GameObject _menu;
        private Character _character;
        private MapLoader _loader;

        [Inject]
        private void Construct(Character character, StartVaweButton startButton, SpawnInstaller spawnInstaller, MapLoader loader)
        {
            _startButton = startButton.StartButton;
            _spawnInstaller = spawnInstaller.GetComponent<Entity>();
            _menu = startButton.Menu;
            _character = character;
            _startButton.onClick.AddListener(StartNextWave);
            _loader = loader;
        }

        private void StartNextWave()
        {
            _loader.LoadMap();
            _spawnInstaller.SetData(new StartWaveRequest());
            _character.transform.position = Vector3.zero;
            _menu.SetActive(false);
        }

        public void Dispose()
        {
            _startButton.onClick.RemoveListener(StartNextWave);
        }
    }
}