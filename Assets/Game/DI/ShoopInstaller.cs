using OtusProject.Shoop;
using OtusProject.View;
using Zenject;
using OtusProject.ItemSystem;
using UnityEngine;

namespace OtusProject.Installer
{
    public class ShoopInstaller : MonoInstaller
    {
        [SerializeField] private ShopPresenter _shopPopup;
        public override void InstallBindings()
        {
            Container.Bind<ShopBuyer>().AsSingle().NonLazy();
            Container.Bind<ShopPresenter>().FromInstance(_shopPopup).AsSingle();
            Container.Bind<IProduct>().To<HealthBottleBuyer>().AsSingle().NonLazy();    
        }
    }
}