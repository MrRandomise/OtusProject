using OtusProject.ItemSystem;
using OtusProject.RecourcesConfig;
using OtusProject.Shoop;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace OtusProject.View
{
    //ShopPresenter
    public sealed class ShopPopup : MonoBehaviour
    {
        [SerializeField] private GameObject _menu;
        [SerializeField] public List<ProductConfig> _sellItem = new List<ProductConfig>();
        [SerializeField] private ProductView _productView;
        [SerializeField] private Transform _container;

        [Inject]
        private ShopManager _shopManager;
        [Inject]
        private ResourcesStorage _resource;

        private List<ShopSystem> _managerList = new List<ShopSystem>();
        private ItemCreator _creator;

        private void Awake()
        {
            //_waveSystem.OnStopTimerEndWave += ShowPopup;
            _creator = new ItemCreator(_productView, _container);
            ShoopInitial();
        }

        private void ShoopInitial()
        {
            foreach (var product in _sellItem)
            {
                var view = _creator.AddItemPanel();
                var shopManager = new ShopSystem(product, view, _shopManager, _resource);
                _managerList.Add(shopManager);
            }
        }

        public void ShowPopup()
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
            //_waveSystem.Start();
            _menu.SetActive(false);
        }

        private void OnDisable()
        {
            //_waveSystem.OnStopTimerEndWave -= ShowPopup;
        }
    }
}