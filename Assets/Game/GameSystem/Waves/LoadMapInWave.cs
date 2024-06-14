using OtusProject.Config.Map;
using OtusProject.Player;
using UnityEngine;

namespace OtusProject.Waves
{
    public sealed class LoadMapInWave 
    {
        private readonly MapLoader _loader;
        private readonly CharacterInstaller _character;
        private EndWave _endWave;

        LoadMapInWave(CharacterInstaller character, MapLoader loader, EndWave endWave)
        {
            _character = character;
            _loader = loader;
            _endWave = endWave;
            _endWave.OnStopTimer += LoadNewWave;
        }

        public void LoadNewWave()
        {
            _loader.ChangeMap();
            _character.transform.position = Vector3.zero;
        }

        public void Dispose()
        {
            _endWave.OnStopTimer -= LoadNewWave;
        }
    }
}