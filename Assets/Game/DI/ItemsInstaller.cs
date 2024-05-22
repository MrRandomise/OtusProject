using OtusProject.ItemSystem;
using OtusProject.ShoopSystem;
using Zenject;

namespace OtusProject.Installer
{
    public class ItemsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Items>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<HealthBottle>().AsSingle().NonLazy();
        }
    }
}