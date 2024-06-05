using System;
using UnityEngine;
using Zenject;

namespace OtusProject.Waves
{
    public sealed class WaveSystem: ITickable
    {
        public event Action OnStartWave;
        public event Action OnStopWave;
        private readonly WaveView _waveView;
        private float _currentTimer = 0;
        private bool _startTimer = false;
        private bool _stopTimer = false;

        public WaveSystem(WaveView waveView)
        {
            _waveView = waveView;
            Star();
        }

        public void Star() => _startTimer = true;
        public void Stop() => _startTimer = true;

        private void EnableTimer()
        {
            _currentTimer += Time.deltaTime;
            if (_currentTimer >= _waveView.StartTimeout)
            {
                _currentTimer = 0;
                _startTimer = false;
                OnStartWave?.Invoke();
            }
        }

        private void DisableTimer() 
        {
            _currentTimer += Time.deltaTime;
            if (_currentTimer >= _waveView.EndTimeout)
            {
                _currentTimer = 0;
                _stopTimer = false;
                OnStopWave?.Invoke();
            }
        }

        public void Tick()
        {
            if(_startTimer)
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
