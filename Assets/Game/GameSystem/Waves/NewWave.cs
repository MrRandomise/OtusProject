using OtusProject.Config.Map;
using OtusProject.Player;
using OtusProject.Waves;
using System;
using UnityEngine;
namespace OtusProject.View
{
    public sealed class NewWave : IDisposable
    {
        private readonly MapLoader _loader;
        private readonly CharacterInstaller _character;
        private WaveSystem _waveSystem;
        
        NewWave(CharacterInstaller character, MapLoader loader, WaveSystem waveSystem)
        {
            _character = character;
            _loader = loader;
            _waveSystem = waveSystem;
            _waveSystem.OnStopTimerEndWave += LoadNewWave;
        }

        public void LoadNewWave()
        {
            _loader.ChangeMap();
            _character.transform.position = Vector3.zero;
        }

        public void Dispose()
        {
            _waveSystem.OnStopTimerEndWave -= LoadNewWave;
        }
    }
}