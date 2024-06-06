using OtusProject.Config.Map;
using OtusProject.Content;
using UnityEngine;
using UnityEngine.UI;

namespace OtusProject.Waves
{
    public sealed class WaveView : MonoBehaviour
    {
        [SerializeField] private GameObject _menu;
        [SerializeField] private Button _startButton;
        private readonly MapLoader _loader;
        private readonly CharacterInstaller _character;
        public readonly float StartTimeout = 3;
        public readonly float EndTimeout = 3;

        public WaveView(MapLoader loader, CharacterInstaller character)
        {
            _character = character;
            _startButton.onClick.AddListener(StartNextWave);
            _loader = loader;
        }

        private void StartNextWave()
        {
            _loader.ChangeMap();
            _character.transform.position = Vector3.zero;
            _menu.SetActive(false);
        }

        public void Dispose()
        {
            _startButton.onClick.RemoveListener(StartNextWave);
        }
    }
}

