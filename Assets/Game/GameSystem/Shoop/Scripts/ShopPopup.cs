using OtusProject.Waves;
using UnityEngine;
using Zenject;
namespace OtusProject.View
{
    public sealed class ShopPopup : MonoBehaviour
    {
        [SerializeField] private GameObject _menu;
        private WaveSystem _waveSystem;

        [Inject]
        private void Construct(WaveSystem waveSystem)
        {
            _waveSystem = waveSystem;
            _waveSystem.OnStopWave += ShowPopup;
        }

        private void ShowPopup() => _menu.SetActive(true);
        public void HidePopup()
        {
            _waveSystem.Start();
            _menu.SetActive(false);
        }

        private void OnDisable()
        {
            _waveSystem.OnStopWave -= ShowPopup;
        }
    }
}