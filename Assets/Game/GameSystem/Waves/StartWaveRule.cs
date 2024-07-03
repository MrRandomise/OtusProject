using Leopotam.EcsLite.Entities;
using OtusProject.Component;
using OtusProject.Config.Map;
using OtusProject.Player;
using OtusProject.Waves;
using System;
using UnityEngine;

namespace OtusProject.View
{
    public sealed class StartWaveRule : IDisposable
    {
        private readonly MapLoader _loader;
        private readonly Entity _character;
        private WaveSystem _waveSystem;
        
        public StartWaveRule(CharacterInstaller character, MapLoader loader, WaveSystem waveSystem)
        {
            _character = character.GetComponent<Entity>();
            _loader = loader;
            _waveSystem = waveSystem;
            _waveSystem.OnTimerEndWave += LoadNewWave;
        }

        public void LoadNewWave()
        {
            _loader.ChangeMap();
            _character.GetData<CanMove>().Value = true;
            _character.transform.position = Vector3.zero;
        }

        public void Dispose()
        {
            _waveSystem.OnTimerEndWave -= LoadNewWave;
        }
    }
}