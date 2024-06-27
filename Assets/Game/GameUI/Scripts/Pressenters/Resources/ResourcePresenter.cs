using OtusProject.View;
using System;

namespace OtusProject.RecourcesConfig
{
    public class ResourcePresenter : IDisposable
    {
        private ResourcesStorage _resourcesStorage;
        private CoinView _coinView;
        ResourcePresenter(ResourcesStorage resourcesStorage, CoinView coinView)
        {
            _resourcesStorage = resourcesStorage;
            _coinView = coinView;
            _resourcesStorage.OnChangeResources += UpdateResources;
        }

        private void UpdateResources(int ammount)
        {
            _coinView.SetCoinView(ammount);
        }

        public void Dispose()
        {
            _resourcesStorage.OnChangeResources -= UpdateResources;
        }
    }
}
