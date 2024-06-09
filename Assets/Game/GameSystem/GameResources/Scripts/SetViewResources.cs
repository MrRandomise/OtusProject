using OtusProject.Player;
using System;
namespace OtusProject.RecourcesConfig
{
    public class SetViewResources : IDisposable
    {
        private GetResources _getResources;
        private ResourcesStorage _resourcesStorage;
        SetViewResources(CharacterInstaller characterInstaller, ResourcesStorage resourcesStorage)
        {
            _getResources = characterInstaller.GetComponent<GetResources>();
            _getResources.onGetResources += UpdateViewResources;
            _resourcesStorage = resourcesStorage;
        }

        private void UpdateViewResources(ResourcesInstaler key)
        {
            _resourcesStorage.SetAmmountResources(key);
            var tMP_Text = key.View.Value;
            var ammount = _resourcesStorage.GetAmmountResources(key);
            tMP_Text.text = $" x {ammount}";
        }

        public void Dispose()
        {
            _getResources.onGetResources -= UpdateViewResources;
        }
    }
}
