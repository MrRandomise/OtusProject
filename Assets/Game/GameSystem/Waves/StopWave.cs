using Leopotam.EcsLite.Entities;
using OtusProject.Waves;
using System;
using OtusProject.Component.Events;
using OtusProject.Player;

namespace OtusProject.View
{
    public sealed class StopWave : IDisposable
    {
        private Wave _waveSystem;
        private Entity _character;
        public StopWave(Wave waveSystem, CharacterInstaller character)
        {
            _waveSystem = waveSystem;
            _character = character.GetComponent<Entity>();
            _waveSystem.OnEndWave += EndWaveEvent;
        }

        public void EndWaveEvent()
        {
            _character.SetData(new EndWaveEvent());
        }

        public void Dispose()
        {
            _waveSystem.OnEndWave -= EndWaveEvent;
        }
    }
}