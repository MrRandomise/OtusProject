using Zenject;
using OtusProject.View;
using OtusProject.ItemSystem;
using UnityEngine;

namespace OtusProject.ShoopSystem
{
    public sealed class ShoopView 
    {
        private ShoopMono _shoopMono;
        private ItemsPanel _itemPanel;
        private ShoopNoBuyTimer _timer;

        [Inject]
        private void Construct(ShoopMono shoopMono, ShoopNoBuyTimer timer)
        {
            _shoopMono = shoopMono;
            _itemPanel = _shoopMono.ContentPrefab;
            _timer = timer;
            ShoopInitial();
        }

        private void ShoopInitial()
        {
            foreach(var item in _shoopMono.sellItem)
            {
                Add(item);
            }
        }

        public void Add(ItemConfig item)
        {
            var itemContent = GameObject.Instantiate(_itemPanel);
            itemContent.transform.SetParent(_shoopMono.Content);
            itemContent.Icon.sprite = item.Component.GetIcon();
            itemContent.CoinIcon.sprite = item.Resource.Icon;
            itemContent.PriceText.text = item.Price.ToString();
            new ShoopBuy(item, itemContent, _timer);
        }
    }
}