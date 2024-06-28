using OtusProject.Waves;
using Zenject;
using UnityEngine;

namespace OtusProject.View
{
    public class ShowHideShopPresenter : MonoBehaviour
    {
        [SerializeField] private ShopPresenter _popup;
        private Wave _wave;

        [Inject]
        private void Construct(Wave wave)
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
            _wave.Start();
        }

        private void OnDisable()
        {
            _wave.OnTimerEndWave -= _popup.ShowPopup;
        }

    }
}