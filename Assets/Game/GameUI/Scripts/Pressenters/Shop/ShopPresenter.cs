using OtusProject.ItemSystem;
using OtusProject.RecourcesConfig;
using OtusProject.Shoop;
using System.Collections.Generic;
using UnityEngine;
using OtusProject.ModulesUI;
using Zenject;

namespace OtusProject.View
{
    public sealed class ShopPresenter : MonoBehaviour
    {
        [SerializeField] private GameObject _menu;
        [SerializeField] public List<ProductConfig> _sellItem = new List<ProductConfig>();
        [SerializeField] private ProductView _productView;
        [SerializeField] private Transform _container;

        [Inject]
        private ShopBuyer _shopManager;
        [Inject]
        private ResourcesStorage _resource;

        private List<ShopSystem> _managerList = new List<ShopSystem>();

        private void Awake()
        {
            ShoopInitial();
        }

        private void ShoopInitial()
        {
            foreach (var product in _sellItem)
            {
                
                var view = GameObject.Instantiate(_productView, _productView.transform.position, Quaternion.identity, _container);
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
            _menu.SetActive(false);
        }
    }
}