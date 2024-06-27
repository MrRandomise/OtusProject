using OtusProject.View;
using UnityEngine;
using Zenject;

namespace OtusProject.Waves
{
    public sealed class WaveMessagePresenter : ITickable
    {
        private WaveTextView _waveTextView;
        private WaveView _waveView;
        private Wave _waveSystem;
        private float _messageTimer = 0;
        private bool _startWave = false;


        WaveMessagePresenter(WaveTextView waveTextView, WaveView waveView, Wave waveSystem)
        {
            _waveTextView = waveTextView;
            _waveView = waveView;
            _waveSystem = waveSystem;
            _messageTimer = _waveSystem._endTimeout;
            _waveSystem.OnSartWave += StartMessageUpdate;
            _waveSystem.OnEndWave += EndMessageUpdate;
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

        private void ClearEndMessage()
        {
            _waveView.ClearMessage();
        }

        private void TimeToStartWave()
        {
            _messageTimer -= Time.deltaTime;
            _waveView.SetTimerView(_messageTimer);
            if (_messageTimer < 0)
            {
                _startWave = false;
                _messageTimer = _waveSystem._endTimeout;
                ClearEndMessage();
            }
        }

        public void Tick()
        {
            if(_startWave)
            {
                TimeToStartWave();
            }
        }
    }
}
