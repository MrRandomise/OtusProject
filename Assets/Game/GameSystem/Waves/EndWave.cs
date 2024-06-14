using Leopotam.EcsLite.Entities;
using OtusProject.Player;
using System;
using OtusProject.Component.Events;
using UnityEngine;
using Zenject;

namespace OtusProject.Waves
{
    public sealed class EndWave : ITickable
    {
        private float _currentTimer = 0;
        public readonly float _timeout = 3;
        private bool _startTimer = false;
        private int _currentWave = 0;
        public event Action OnSartTimer;
        public event Action OnStopTimer;
        private Entity _entity;
        private CharacterInstaller _character;

        public EndWave(CharacterInstaller character)
        {
            _character = character;
            _entity = character.GetComponent<Entity>();
        }

        public int GetCurrentWave() => _currentWave;

        private void ChangeWave() => _currentWave++;

        public void StartTimer()
        {
            OnSartTimer?.Invoke();
            _entity.SetData(new EndWaveEvent());
            _startTimer = true;
        }

        private void Timer()
        {
            _currentTimer += Time.deltaTime;
            if (_currentTimer >= _timeout)
            {
                _currentTimer = 0;
                _startTimer = false;
                _character.IsAlive = false;
                ChangeWave();
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