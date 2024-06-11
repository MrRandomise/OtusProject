using OtusProject.ItemSystem;
using OtusProject.View;
using System.Collections.Generic;
using UnityEngine;

namespace OtusProject.Shoop
{
    public class ShoopMeneger : MonoBehaviour
    {
        [SerializeField] private List<ItemConfig> _sellItem = new List<ItemConfig>();
        [SerializeField] private ItemsShopPanel _shopPanel;
        [SerializeField] private Transform _container;
        private ContentItemCreator _creator;

        private void Awake()
        {
            _creator = new ContentItemCreator(_shopPanel, _container);
            ShoopInitial();
        }

        private void ShoopInitial()
        {
            foreach (var item in _sellItem)
            {
                Add(item);
            }
        }

        public void Add(ItemConfig item)
        {
            var itemContent = _creator.AddItemPanel();
            itemContent.Icon.sprite = item.Component.GetIcon();
            itemContent.BuyButton.SetIcon(item.Resource.Icon);
            itemContent.BuyButton.SetPrice(item.Price.ToString());
        }
    }
}

