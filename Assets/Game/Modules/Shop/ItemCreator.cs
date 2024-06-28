using OtusProject.View;
using UnityEngine;

namespace OtusProject.Shoop
{
    public sealed class ItemCreator
    {
        private ProductView _contentPrefab;
        private Transform _container;
        public ItemCreator(ProductView contentPrefab, Transform container)
        {
            _contentPrefab = contentPrefab;
            _container = container;
        }
        
        public ProductView AddItemPanel() => GameObject.Instantiate(_contentPrefab, _contentPrefab.transform.position, Quaternion.identity, _container);

    }
}
