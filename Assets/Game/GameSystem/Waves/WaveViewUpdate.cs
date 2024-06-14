using OtusProject.View;
using System;

namespace OtusProject.Waves
{
    public sealed class WaveViewUpdate : IDisposable
    {
        private WaveView _waveView;
        private EndWave _endWave;

        WaveViewUpdate(WaveView waveView, EndWave endWave)
        {
            _waveView = waveView;
            _endWave = endWave;
            _endWave.OnStopTimer += ViewUpdate;
        }

        private void ViewUpdate()
        {
            _waveView.SetWaveView(_endWave.GetCurrentWave());
        }

        public void Dispose()
        {
            _endWave.OnStopTimer -= ViewUpdate;
        }
    }
}
