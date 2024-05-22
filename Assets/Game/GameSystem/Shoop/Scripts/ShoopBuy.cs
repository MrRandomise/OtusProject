using OtusProject.ItemSystem;
using OtusProject.View;
using System;
using UnityEngine;

namespace OtusProject.ShoopSystem
{
    public class ShoopBuy: IDisposable
    {
        private ItemConfig _config;
        private ItemsPanel _view;
        private ShoopNoBuyTimer _timer;
        private Color _colorError = Color.red;
        private Color _colorAccept = Color.green;

        
        public ShoopBuy(ItemConfig config, ItemsPanel view, ShoopNoBuyTimer timer)
        {
            _config = config;
            _view = view;
            _view.BuyButton.onClick.AddListener(ClickButton);
            _timer = timer;
        }

        private void ClickButton()
        {
            if(_config.Resource.GetCountResources() < _config.Price && _view.PriceText.color != _colorError)
            {
                _view.PriceText.color = _colorError;
            }
            else if(_config.Resource.GetCountResources() >= _config.Price)
            {
                _view.PriceText.color = _colorAccept;
                _config.Resource.SetCountResources(-_config.Price);
                _config.SetCurrBuy();
                _config.UseItem();
                if (_config.MaxBuy <= _config.GetCurrBuy())
                {
                    Remove();
                }
            }
            _timer.Start(ref _view.PriceText);
        }

        public void Remove()
        {
            _view.RemoveContent();
            Dispose();
        }

        public void Dispose()
        {
            _view.BuyButton.onClick.RemoveListener(ClickButton);
        }
    }
}
