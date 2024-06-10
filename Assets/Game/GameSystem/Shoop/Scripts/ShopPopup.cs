using OtusProject.Waves;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
namespace OtusProject.View
{
    public sealed class ShopPopup : MonoBehaviour
    {
        [SerializeField] private GameObject _menu;
        [SerializeField] private Button _startButton;
        private WaveSystem _waveSystem;

        [Inject]
        private void Construct(WaveSystem waveSystem)
        {
            _waveSystem = waveSystem;
            _waveSystem.OnStopWave += ShowPopup;
            _startButton.onClick.AddListener(HidePopup);
        }

        private void ShowPopup() => _menu.SetActive(true);
        private void HidePopup()
        {
            _waveSystem.Start();
            _menu.SetActive(false);
        }

        private void OnDisable()
        {
            _waveSystem.OnStopWave -= ShowPopup;
            _startButton.onClick.RemoveListener(HidePopup);
        }
    }
}