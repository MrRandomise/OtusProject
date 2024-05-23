using System;
using OtusProject.Content;
using UnityEngine.UI;
using Zenject;
using Leopotam.EcsLite.Entities;
using OtusProject.Component.Request;
using UnityEngine;
using OtusProject.Player;

namespace OtusProject.View
{
    public sealed class StartVawe : IDisposable
    {
        private Button _startButton;
        private Entity _spawnInstaller;
        private GameObject _menu;
        private Character _character;
        [Inject]
        private void Construct(Character character, StartVaweButton startButton, SpawnInstaller spawnInstaller)
        {
            _startButton = startButton.StartButton;
            _spawnInstaller = spawnInstaller.GetComponent<Entity>();
            _menu = startButton.Menu;
            _character = character;
            _startButton.onClick.AddListener(StartNextWave);
        }

        private void StartNextWave()
        {
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