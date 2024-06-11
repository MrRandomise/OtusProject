using OtusProject.View;
using UnityEngine;

namespace OtusProject.Shoop
{
    public sealed class ContentItemCreator
    {
        private ItemsShopPanel _contentPrefab;
        private Transform _container;
        public ContentItemCreator(ItemsShopPanel contentPrefab, Transform container)
        {
            _contentPrefab = contentPrefab;
            _container = container;
        }
        
        public ItemsShopPanel AddItemPanel() => GameObject.Instantiate(_contentPrefab, _contentPrefab.transform.position, Quaternion.identity, _container);

    }
}

