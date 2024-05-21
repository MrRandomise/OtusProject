using OtusProject.Config.Weapon;
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
        

        public ShoopBuy(ItemConfig config, ItemsPanel view)
        {
            _config = config;
            _view = view;
            _view.BuyButton.onClick.AddListener(ClickButton);
            _timer = new ShoopNoBuyTimer();
        }

        private void ClickButton()
        {
            if(_config.Resource.GetCountResources() < _config.Price && _view.PriceText.color != _colorError)
            {
                _view.PriceText.color = _colorError;
                _timer.Start(ref _view.PriceText);
            }
            else if(_config.Resource.GetCountResources() >= _config.Price)
            {
                _view.PriceText.color = _colorAccept;

                Remove();
            }
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
