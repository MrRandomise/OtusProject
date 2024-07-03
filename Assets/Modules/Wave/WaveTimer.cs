using System;
using UnityEngine;
using Zenject;
namespace OtusProject.Waves
{
    public enum WaveAction
    {
        StartNewWave,
        TimeOutWave
    }

    public sealed class WaveTimer : ITickable
    {
        private float _timerTimeout;
        private float _currentTimer = 0;
        private bool _startTimer = false;
        private WaveAction _waveAction;
        public event Action<WaveAction> CompleteTimer;

        public void StartTimer(WaveAction waveAction, float timeOut)
        {
            _waveAction = waveAction;
            _timerTimeout = timeOut;
            _startTimer = true;
        }

        public void StopTimer()
        {
            _startTimer = false;
        }

        private void Timer()
        {
            _currentTimer += Time.deltaTime;
            if (_currentTimer >= _timerTimeout)
            {
                _currentTimer = 0;
                _startTimer = false;
                CompleteTimer?.Invoke(_waveAction);
            }
        }

        public void Tick()
        {
            if (_startTimer)
            {
                Timer();
            }
        }
    }
}