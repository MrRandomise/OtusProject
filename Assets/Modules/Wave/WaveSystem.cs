using System;
using Zenject;

namespace OtusProject.Waves
{
    public sealed class WaveSystem : IInitializable
    {
        public event Action OnTimerStartWave;
        public event Action OnSartWave;
        public event Action OnEndWave;
        public event Action OnTimerEndWave;
        public float TimeOut = 3;

        private WaveTimer _timer;
        private int _currentWave = 0;

        WaveSystem(WaveTimer timer)
        {
            _timer = timer;
            _timer.CompleteTimer += EndTimer;
        }

        public void Initialize()
        {
            StartTimeOutNewWave();
        }

        public void StartTimeOutNewWave()
        {
            OnSartWave?.Invoke();
            _timer.StartTimer(WaveAction.StartNewWave, TimeOut);
        }

        public void StopTimeOutWave()
        {
            OnEndWave?.Invoke();
            _timer.StartTimer(WaveAction.TimeOutWave, TimeOut);
        }

        public int GetCurrentWave() => _currentWave;

        private void EndTimer(WaveAction waveAction)
        {
            if(waveAction == WaveAction.StartNewWave)
            {
                _currentWave++;
                OnTimerStartWave?.Invoke();
            }
            else
            {
                OnTimerEndWave?.Invoke();
            }
        }
    }
}

