using OtusProject.ItemSystem;
using OtusProject.RecourcesConfig;
using OtusProject.Shoop;
using OtusProject.Waves;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace OtusProject.View
{
    public sealed class ShopPopup : MonoBehaviour
    {
        [SerializeField] private GameObject _menu;
        [SerializeField] public List<ProductConfig> _sellItem = new List<ProductConfig>();
        [SerializeField] private ProductView _productView;
        [SerializeField] private Transform _container;

        [Inject]
        private ShopSystem _shopSystem;
        [Inject]
        private ResourcesStorage _resource;
        [Inject]
        private WaveSystem _waveSystem;

        private List<ShopMeneger> _managerList = new List<ShopMeneger>();
        private ContentItemCreator _creator;

        private void Awake()
        {
            _waveSystem.OnStopTimerEndWave += ShowPopup;
            _creator = new ContentItemCreator(_productView, _container);
            ShoopInitial();
        }

        private void ShoopInitial()
        {
            foreach (var product in _sellItem)
            {
                var view = _creator.AddItemPanel();
                var shopManager = new ShopMeneger(product, view, _shopSystem, _resource);
                _managerList.Add(shopManager);
            }
        }

        private void ShowPopup()
        {
            foreach(var manager in _managerList)
            {
                manager.Enable();
            }
            _menu.SetActive(true);
        }

        public void HidePopup()
        {
            foreach (var manager in _managerList)
            {
                manager.Disabled();
            }
            _waveSystem.Start();
            _menu.SetActive(false);
        }

        private void OnDisable()
        {
            _waveSystem.OnStopTimerEndWave -= ShowPopup;
        }
    }
}