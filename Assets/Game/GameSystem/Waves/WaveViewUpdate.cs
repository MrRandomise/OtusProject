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
            _waveSystem.OnStartWave += ViewUpdate;
        }

        private void ViewUpdate()
        {
            _waveView.Waves.text = $"x {_waveSystem.GetCurrentWave()}";
        }

        public void Dispose()
        {
            _waveSystem.OnStartWave -= ViewUpdate;
        }
    }
}
