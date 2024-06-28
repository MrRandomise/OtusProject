using OtusProject.ItemSystem;
using OtusProject.RecourcesConfig;

namespace OtusProject.Shoop
{
    public sealed class ShopBuyer
    {
        private ResourcesStorage _resource;

        ShopBuyer(ResourcesStorage resource)
        {
            _resource = resource;
        }

        public bool TryBuy(ProductConfig product)
        {
            if(CanBay(product))
            {
                var resId = product.Resource.name;
                _resource.SetAmmountResources(resId, -product.Price);
                product.CurrBuy++;
                product.Product.BuyProduct();
                return true;
            }
            return false;
        }

        public bool CanBay(ProductConfig product)
        {
            var resId = product.Resource.name;
            return _resource.GetAmmountResources(resId) >= product.Price && product.CurrBuy < product.MaxBuy;
        }
    }
}
