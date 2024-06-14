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
        private EndWave _endWave;
        [Inject]
        private NewWave _newWave;

        private List<ShopMeneger> _managerList = new List<ShopMeneger>();
        private ContentItemCreator _creator;

        private void Awake()
        {
            _endWave.OnStopTimer += ShowPopup;
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
            _newWave.StartTimer();
            _menu.SetActive(false);
        }

        private void OnDisable()
        {
            _endWave.OnStopTimer += ShowPopup;
        }
    }
}