using System;
using OtusProject.Content;
using UnityEngine.UI;
using Zenject;
using Leopotam.EcsLite.Entities;
using OtusProject.Component.Request;
using UnityEngine;

namespace OtusProject.View
{
    public sealed class StartVawe : IDisposable
    {
        private Button _startButton;
        private Entity _spawnInstaller;
        private GameObject _menu;

        [Inject]
        private void Construct(StartVaweButton startButton, SpawnInstaller spawnInstaller)
        {
            _startButton = startButton.StartButton;
            _spawnInstaller = spawnInstaller.GetComponent<Entity>();
            _menu = startButton.Menu;
            _startButton.onClick.AddListener(StartNextWave);
        }

        private void StartNextWave()
        {
            _spawnInstaller.SetData(new StartWaveRequest());
            _menu.SetActive(false);
        }

        public void Dispose()
        {
            _startButton.onClick.RemoveListener(StartNextWave);
        }
    }
}