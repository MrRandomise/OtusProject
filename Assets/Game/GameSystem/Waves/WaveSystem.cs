using OtusProject.Player;
using System;
using UnityEngine;
using Zenject;

namespace OtusProject.Waves
{
    public sealed class WaveSystem : ITickable, IInitializable
    {
        private CharacterInstaller _characterInstaller;
        public event Action OnStopTimerStartWave;
        public event Action OnSartWave;
        public event Action OnEndWave;
        public event Action OnStopTimerEndWave;
        public readonly float _startTimeout = 3;
        public readonly float _endTimeout = 3;
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
            OnSartWave?.Invoke();
            _characterInstaller.IsAlive = true;
            _startTimer = true;
        }

        public void Stop()
        {
            OnEndWave?.Invoke();
            _stopTimer = true;
        }

        public int GetCurrentWave() => _currentWave;

        private void EnableWaveTimer()
        {
            _currentTimer += Time.deltaTime;
            if (_currentTimer >= _startTimeout)
            {
                _currentTimer = 0;
                _startTimer = false;
                _currentWave++;
                OnStopTimerStartWave?.Invoke();
            }
        }

        private void DisableWaveTimer()
        {
            _currentTimer += Time.deltaTime;
            if (_currentTimer >= _endTimeout)
            {
                _currentTimer = 0;
                _stopTimer = false;
                _characterInstaller.IsAlive = false;
                OnStopTimerEndWave?.Invoke();
            }
        }

        public void Tick()
        {
            if (_startTimer)
            {
                EnableWaveTimer();
            }
            if (_stopTimer)
            {
                DisableWaveTimer();
            }
        }
    }
}

