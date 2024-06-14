using OtusProject.View;
using UnityEngine;
using Zenject;

namespace OtusProject.Waves
{
    public sealed class WaveTextUpdate : ITickable
    {
        private WaveTextView _waveTextView;
        private WaveView _waveView;
        private WaveSystem _waveSystem;
        private float _timerLastMessage = 2;
        private float _currTimer = 0;
        private float _lastMessageTimer = 0;
        private bool _startWave = false;
        private bool _lastMessage = false;


        WaveTextUpdate(WaveTextView waveTextView, WaveView waveView, WaveSystem waveSystem)
        {
            _waveTextView = waveTextView;
            _waveView = waveView;
            _waveSystem = waveSystem;
            _lastMessageTimer = _waveSystem._endTimeout;
            _waveSystem.OnSartWave += StartMessageUpdate;
            _waveSystem.OnEndWave += EndMessageUpdate;
            _waveSystem.OnStopTimerStartWave += LastMessage;
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
                _lastMessageTimer = _waveSystem._endTimeout;
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
    }
}
