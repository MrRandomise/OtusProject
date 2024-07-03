using OtusProject.View;
using System;

namespace OtusProject.Waves
{
    public sealed class WaveViewPresenter : IDisposable
    {
        private WaveView _waveView;
        
        private WaveSystem _waveSystem;

        WaveViewPresenter(WaveView waveView, WaveSystem waveSystem)
        {
            _waveView = waveView;
            _waveSystem = waveSystem;
            _waveSystem.OnTimerStartWave += ViewUpdate;
        }

        private void ViewUpdate()
        {
            _waveView.SetWaveView(_waveSystem.GetCurrentWave());
        }

        public void Dispose()
        {
            _waveSystem.OnTimerStartWave -= ViewUpdate;
        }
    }
}
