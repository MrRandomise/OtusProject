using OtusProject.Config.Map;
using UnityEngine;
using Zenject;
namespace OtusProject.Installer
{
    public class MapInstaller : MonoInstaller
    {
        [SerializeField] private StartScene _startScene;
        public override void InstallBindings()
        {
            Container.Bind<MapLoader>().AsSingle().NonLazy();
            Container.Bind<StartScene>().FromComponentInNewPrefab(_startScene).AsSingle().NonLazy();
        }
    }
}