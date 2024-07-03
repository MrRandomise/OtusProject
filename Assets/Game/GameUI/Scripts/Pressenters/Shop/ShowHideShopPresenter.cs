using OtusProject.Waves;
using Zenject;
using UnityEngine;

namespace OtusProject.View
{
    public class ShowHideShopPresenter : MonoBehaviour
    {
        [SerializeField] private ShopPresenter _popup;
        private WaveSystem _wave;

        [Inject]
        private void Construct(WaveSystem wave)
        {
            _wave = wave;
        }

        private void Awake()
        {
            _wave.OnTimerEndWave += _popup.ShowPopup;
        }

        public void HidePopup()
        {
            _popup.HidePopup();
            _wave.StartTimeOutNewWave();
        }

        private void OnDisable()
        {
            _wave.OnTimerEndWave -= _popup.ShowPopup;
        }

    }
}