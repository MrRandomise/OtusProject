using OtusProject.ItemSystem;
using OtusProject.RecourcesConfig;
using OtusProject.View;
using UnityEngine;

namespace OtusProject.Shoop
{
    public sealed class ShopMeneger
    {
        private ProductView _productView;
        private ProductConfig _product;
        private ShopSystem _shopSystem;
        private ResourcesStorage _resource;

        public ShopMeneger(ProductConfig product, ProductView productView, ShopSystem shopSystem, ResourcesStorage resource)
        {
            _product = product;
            _productView = productView;
            _shopSystem = shopSystem;
            _resource = resource;
        }

        public void Enable()
        {
            _resource.OnChangeResources += OnMoneyChange;

            _productView.Icon.sprite = _product.Product.GetIcon();
            _productView.BuyButton.AddListener(OnBuyClick);
            _productView.BuyButton.SetIcon(_product.Resource.Icon);
            _productView.BuyButton.SetPrice(_product.Price.ToString());
            UpdateButtonState();
        }


        private void OnBuyClick()
        {
            if(_shopSystem.CanBay(_product))
            {
                _shopSystem.Buy(_product);
            }
        }

        private void OnMoneyChange(int ammount)
        {
            UpdateButtonState();
        }

        private void UpdateButtonState()
        {
            _productView.BuyButton.SetAvailable(_shopSystem.CanBay(_product));
        }

        public void Disabled()
        {
            _resource.OnChangeResources -= OnMoneyChange;
            _productView.BuyButton.RemoveListener(OnBuyClick);
        }


    }
}

