using OtusProject.Player;
using System;
using UnityEngine;
using Zenject;

namespace OtusProject.Waves
{
    public sealed class WaveSystem : ITickable, IInitializable
    {
        private CharacterInstaller _characterInstaller;
        public event Action OnStartWave;
        public event Action OnStopWave;
        private readonly float _startTimeout = 3;
        private readonly float _endTimeout = 3;
        private int _currentWave = 0;
        private float _currentTimer = 0;
        private bool _startTimer = false;
        private bool _stopTimer = false;

        WaveSystem(CharacterInstaller characterInstaller)
        {
            _characterInstaller = characterInstaller;
        }

        public void Initialize()
        {
            Start();
        }

        public void Start()
        {
            _characterInstaller.IsAlive = true;
            _startTimer = true;
        }

        public void Stop() => _stopTimer = true;

        public int GetCurrentWave() => _currentWave;

        private void EnableTimer()
        {
            _currentTimer += Time.deltaTime;
            if (_currentTimer >= _startTimeout)
            {
                _currentTimer = 0;
                _startTimer = false;
                _currentWave++;
                OnStartWave?.Invoke();
            }
        }

        private void DisableTimer()
        {
            _currentTimer += Time.deltaTime;
            if (_currentTimer >= _endTimeout)
            {
                _currentTimer = 0;
                _stopTimer = false;
                _characterInstaller.IsAlive = false;
                OnStopWave?.Invoke();
            }
        }

        public void Tick()
        {
            if (_startTimer)
            {
                EnableTimer();
            }
            if (_stopTimer)
            { 
                DisableTimer();
            }
        }
    }
}

