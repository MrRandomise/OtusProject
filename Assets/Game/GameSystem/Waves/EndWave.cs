using Leopotam.EcsLite.Entities;
using OtusProject.Player;
using OtusProject.Waves;
using System;
using OtusProject.Component.Events;

namespace OtusProject.View
{
    public sealed class EndWave : IDisposable
    {
        private WaveSystem _waveSystem;
        private Entity _character;
        EndWave(WaveSystem waveSystem, CharacterInstaller character)
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