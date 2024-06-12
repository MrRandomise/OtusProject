using OtusProject.ItemSystem;
using OtusProject.RecourcesConfig;

namespace OtusProject.Shoop
{
    public sealed class ShopSystem
    {
        private ResourcesStorage _resource;

        ShopSystem(ResourcesStorage resource)
        {
            _resource = resource;
        }

        public void Buy(ProductConfig product)
        {
            if(CanBay(product))
            {
                var resId = product.Resource.ID;
                _resource.SetAmmountResources(resId, -product.Price);
                product.CurrBuy++;
                product.Product.BuyItem();
            }
        }

        public bool CanBay(ProductConfig product)
        {
            var resId = product.Resource.ID;
            return _resource.GetAmmountResources(resId) >= product.Price;
        }
    }
}