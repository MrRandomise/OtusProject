using OtusProject.View;
using System;
using UnityEngine;

namespace OtusProject.RecourcesConfig
{
    public class SetViewResources : IDisposable
    {
        private ResourcesStorage _resourcesStorage;
        private CoinView _coinView;
        SetViewResources(ResourcesStorage resourcesStorage, CoinView coinView)
        {
            _resourcesStorage = resourcesStorage;
            _coinView = coinView;
            _resourcesStorage.OnChangeResources += UpdateViewResources;
        }

        private void UpdateViewResources(int ammount)
        {
            _coinView.SetCoinView(ammount);
        }

        public void Dispose()
        {
            _resourcesStorage.OnChangeResources -= UpdateViewResources;
        }
    }
}
