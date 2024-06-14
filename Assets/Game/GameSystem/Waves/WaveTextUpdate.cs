using OtusProject.View;
using System;
using UnityEngine;
using Zenject;

namespace OtusProject.Waves
{
    public sealed class WaveTextUpdate : ITickable, IDisposable
    {
        private WaveTextView _waveTextView;
        private WaveView _waveView;
        private NewWave _newWave;
        private EndWave _endWave;
        private float _timerLastMessage = 2;
        private float _currTimer = 0;
        private float _lastMessageTimer = 0;
        private bool _startWave = false;
        private bool _lastMessage = false;


        WaveTextUpdate(WaveTextView waveTextView, WaveView waveView, NewWave newWave, EndWave endWave)
        {
            _waveTextView = waveTextView;
            _waveView = waveView;
            _newWave = newWave;
            _endWave = endWave;
            _lastMessageTimer = _endWave._timeout;
            _newWave.OnSartTimer += StartMessageUpdate;
            _endWave.OnSartTimer += EndMessageUpdate;
            _newWave.OnStopTimer += LastMessage;
        }

        private void StartMessageUpdate()
        {
            _startWave = true;
            _waveView.SetMessagesView(_waveTextView.GetStartMessage());
        }

        private void EndMessageUpdate()
        {
            _waveView.SetMessagesView(_waveTextView.GetEndMessage());
        }

        private void LastMessage()
        {
            _lastMessage = true;
            _waveView.SetMessagesView(_waveTextView.GetLastMessage());
        }

        private void ClearEndMessage()
        {
            _lastMessage = false;
            _waveView.ClearMessage();
        }

        private void TimeToLastMessage()
        {
            _currTimer += Time.deltaTime;
            if (_currTimer >= _timerLastMessage)
            {
                _currTimer = 0;
                ClearEndMessage();
            }
        }

        private void TimeToStartWave()
        {
            _lastMessageTimer -= Time.deltaTime;
            _waveView.SetTimerView(_lastMessageTimer);
            if (_lastMessageTimer < 0)
            {
                _startWave = false;
                _lastMessageTimer = _endWave._timeout;
            }
        }

        public void Tick()
        {
            if(_lastMessage)
            {
                TimeToLastMessage();
            }
            if(_startWave)
            {
                TimeToStartWave();
            }
        }

        public void Dispose()
        {
            _newWave.OnSartTimer -= StartMessageUpdate;
            _endWave.OnSartTimer -= EndMessageUpdate;
            _newWave.OnStopTimer -= LastMessage;
        }
    }
}
