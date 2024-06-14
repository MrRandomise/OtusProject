using OtusProject.Player;
using System;
using UnityEngine;
using Zenject;

namespace OtusProject.Waves
{
    public sealed class NewWave : ITickable
    {
        private readonly CharacterInstaller _character;
        private float _currentTimer = 0;
        public readonly float _timeout = 3;
        private bool _startTimer = false;
        public event Action OnSartTimer;
        public event Action OnStopTimer;
        
        public NewWave(CharacterInstaller character)
        {
            _character = character;
            StartTimer();
        }


        public void StartTimer()
        {
            _character.IsAlive = true;
            OnSartTimer?.Invoke();
            _startTimer = true;
        }

        private void Timer()
        {
            _currentTimer += Time.deltaTime;
            if (_currentTimer >= _timeout)
            {
                _currentTimer = 0;
                _startTimer = false;
                OnStopTimer?.Invoke();
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