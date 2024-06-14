using OtusProject.Shoop;
using OtusProject.View;
using Zenject;
using OtusProject.ItemSystem;
using UnityEngine;

namespace OtusProject.Installer
{
    public class ShoopInstaller : MonoInstaller
    {
        [SerializeField] private ShopPopup _shopPopup;
        public override void InstallBindings()
        {
            Container.Bind<ShopSystem>().AsSingle().NonLazy();
            Container.Bind<ShopPopup>().FromInstance(_shopPopup).AsSingle();
            Container.Bind<IProduct>().To<HealthBottleBuyer>().AsSingle().NonLazy();    
        }
    }
}