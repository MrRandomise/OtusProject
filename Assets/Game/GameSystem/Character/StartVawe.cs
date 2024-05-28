using System;
using OtusProject.Content;
using UnityEngine.UI;
using Zenject;
using Leopotam.EcsLite.Entities;
using OtusProject.Component.Request;
using UnityEngine;
using OtusProject.Config.Map;

namespace OtusProject.View
{
    public sealed class StartVawe : IDisposable
    {
        private Button _startButton;
        private Entity _spawnInstaller;
        private GameObject _menu;
        private MapLoader _loader;

        public StartVawe (StartVaweButton startButton, SpawnInstaller spawnInstaller, MapLoader loader)
        {
            _startButton = startButton.StartButton;
            _spawnInstaller = spawnInstaller.GetComponent<Entity>();
            _menu = startButton.Menu;
            _startButton.onClick.AddListener(StartNextWave);
            _loader = loader;
        }

        private void StartNextWave()
        {
            _loader.ChangeMap();
            _spawnInstaller.SetData(new StartWaveRequest());
            _menu.SetActive(false);
        }

        public void Dispose()
        {
            _startButton.onClick.RemoveListener(StartNextWave);
        }
    }
}