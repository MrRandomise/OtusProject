using OtusProject.ShoopSystem;
using UnityEngine;
using Zenject;
namespace OtusProject.Installer
{
    public class ShoopInstaller : MonoInstaller
    {
        [SerializeField] private ShoopMono _shoopMono;
        public override void InstallBindings()
        {
            Container.Bind<ShoopMono>().FromInstance(_shoopMono).AsSingle();
            Container.Bind<ShoopView>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ShoopNoBuyTimer>().AsSingle().NonLazy();
        }
    }
}