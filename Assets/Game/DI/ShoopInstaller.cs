using OtusProject.Shoop;
using OtusProject.View;
using Zenject;
using UnityEngine;
namespace OtusProject.Installer
{
    public class ShoopInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ShoopMeneger>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ShoopSystem>().AsSingle().NonLazy();
            Container.Bind<ShopPopup>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ItemsContentView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ItemsView>().FromComponentInHierarchy().AsSingle();
        }
    }
}