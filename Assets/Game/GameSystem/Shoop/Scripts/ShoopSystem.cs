using OtusProject.ItemSystem;
using OtusProject.View;
using System;

namespace OtusProject.Shoop
{
    public class ShoopSystem
    {
        ////private ItemConfig _config;
        //private ItemsPanel _view;
        
        //ShoopSystem(ItemConfig config, ItemsPanel view)
        //{
        //    _config = config;
        //    _view = view;
        //    _view.BuyButton.onClick.AddListener(BuyShoop);
        //}

        //public void BuyShoop()
        //{
        //    if (_config.Resource.GetCountResources() < _config.Price && _view.PriceText.color != _colorError)
        //    {
        //        _view.PriceText.color = _colorError;
        //    }
        //    else if (_config.Resource.GetCountResources() >= _config.Price)
        //    {
        //        _view.PriceText.color = _colorAccept;
        //        _config.Resource.SetCountResources(-_config.Price);
        //        _config.SetCurrBuy();
        //        _config.UseItem();
        //        if (_config.MaxBuy <= _config.GetCurrBuy())
        //        {
        //            Remove();
        //        }
        //    }
        //}

        //public void Remove()
        //{
        //    _view.RemoveContent();
        //    Dispose();
        //}

        //public void Dispose()
        //{
        //    _view.BuyButton.onClick.RemoveListener(BuyShoop);
        //}
    }
}
