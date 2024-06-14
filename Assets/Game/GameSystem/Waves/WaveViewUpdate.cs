using OtusProject.View;
using System;

namespace OtusProject.Waves
{
    public sealed class WaveViewUpdate : IDisposable
    {
        private WaveView _waveView;
        
        private WaveSystem _waveSystem;

        WaveViewUpdate(WaveView waveView, WaveSystem waveSystem)
        {
            _waveView = waveView;
            _waveSystem = waveSystem;
            _waveSystem.OnStopTimerStartWave += ViewUpdate;
        }

        private void ViewUpdate()
        {
            _waveView.SetWaveView(_waveSystem.GetCurrentWave());
        }

        public void Dispose()
        {
            _waveSystem.OnStopTimerStartWave -= ViewUpdate;
        }
    }
}
