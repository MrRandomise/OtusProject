using System;
using UnityEngine;
using Zenject;

namespace OtusProject.Waves
{
    public sealed class Wave : ITickable, IInitializable
    {
        public event Action OnTimerStartWave;
        public event Action OnSartWave;
        public event Action OnEndWave;
        public event Action OnTimerEndWave;
        public readonly float _startTimeout = 3;
        public readonly float _endTimeout = 3;
        private int _currentWave = 0;
        private float _currentTimer = 0;
        private bool _startTimer = false;
        private bool _stopTimer = false;

        public void Initialize()
        {
            Start();
        }

        public void Start()
        {
            OnSartWave?.Invoke();
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
                OnTimerStartWave?.Invoke();
            }
        }

        private void DisableWaveTimer()
        {
            _currentTimer += Time.deltaTime;
            if (_currentTimer >= _endTimeout)
            {
                _currentTimer = 0;
                _stopTimer = false;
                OnTimerEndWave?.Invoke();
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

