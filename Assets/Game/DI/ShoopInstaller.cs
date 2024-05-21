using OtusProject.ShoopSystem;
using OtusProject.View;
using UnityEngine;
using Zenject;
namespace OtusProject.Installer
{
    public class ShoopInstaller : MonoInstaller
    {
        [SerializeField] private StartVaweButton _startVaweButton;
        [SerializeField] private ShoopMono _shoopMono;

        public override void InstallBindings()
        {
            Container.Bind<StartVaweButton>().FromInstance(_startVaweButton).AsSingle();
            Container.Bind<ShoopMono>().FromInstance(_shoopMono).AsSingle();
            Container.Bind<ShoopView>().AsSingle().NonLazy();
            Container.Bind<ShoopNoBuyTimer>().AsSingle();
        }
    }
}