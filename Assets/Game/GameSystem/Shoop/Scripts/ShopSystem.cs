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
                var resId = product.Resource.name;
                _resource.SetAmmountResources(resId, -product.Price);
                product.CurrBuy++;
                product.Product.BuyProduct();
            }
        }

        public bool CanBay(ProductConfig product)
        {
            var resId = product.Resource.name;
            return _resource.GetAmmountResources(resId) >= product.Price && product.CurrBuy < product.MaxBuy;
        }
    }
}
