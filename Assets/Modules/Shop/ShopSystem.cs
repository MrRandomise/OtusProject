using OtusProject.ItemSystem;
using OtusProject.ModulesUI;
using OtusProject.RecourcesConfig;

namespace OtusProject.Shoop
{
    public sealed class ShopSystem
    {
        private ProductView _productView;
        private ProductConfig _product;
        private ShopBuyer _shopSystem;
        private ResourcesStorage _resource;

        public ShopSystem(ProductConfig product, ProductView productView, ShopBuyer shopSystem, ResourcesStorage resource)
        {
            _product = product;
            _productView = productView;
            _shopSystem = shopSystem;
            _resource = resource;
        }

        public void Enable()
        {
            _resource.OnChangeResources += OnResourcesChange;
             ref var icon = ref _product.Icon;
            _productView.Icon.sprite = _product.Icon;
            _productView.BuyButton.AddListener(OnBuyClick);
            _productView.BuyButton.SetIcon(_product.Resource.Icon);
            _productView.BuyButton.SetPrice(_product.Price.ToString());
            UpdateButtonState();
        }


        private void OnBuyClick()
        {
            if(_shopSystem.CanBay(_product))
            {
                _shopSystem.TryBuy(_product);
                UpdateButtonState();
            }
        }

        private void OnResourcesChange(int ammount)
        {
            UpdateButtonState();
        }

        private void UpdateButtonState()
        {
            _productView.BuyButton.SetAvailable(_shopSystem.CanBay(_product));
        }

        public void Disabled()
        {
            _resource.OnChangeResources -= OnResourcesChange;
            _productView.BuyButton.RemoveListener(OnBuyClick);
        }


    }
}

