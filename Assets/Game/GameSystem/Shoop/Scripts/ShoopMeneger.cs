using OtusProject.ItemSystem;
using System.Collections.Generic;
using UnityEngine;
using OtusProject.View;

namespace OtusProject.Shoop
{
    public class ShoopMeneger : MonoBehaviour
    {
        public List<ItemConfig> sellItem = new List<ItemConfig>();
        public Transform Content;
        public ItemsPanel ContentPrefab;

        private ItemsPanel _itemPanel;

        private void Awake()
        {
            _itemPanel = ContentPrefab;
            ShoopInitial();
        }

        private void ShoopInitial()
        {
            foreach (var item in sellItem)
            {
                Add(item);
            }
        }

        public void Add(ItemConfig item)
        {
            var itemContent = GameObject.Instantiate(_itemPanel);
            itemContent.transform.SetParent(Content);
            itemContent.Icon.sprite = item.Component.GetIcon();
            itemContent.CoinIcon.sprite = item.Resource.Icon;
            itemContent.PriceText.text = item.Price.ToString();
        }
    }
}

