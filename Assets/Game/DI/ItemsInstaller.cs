using OtusProject.ItemSystem;
using Zenject;

namespace OtusProject.Installer
{
    public class ItemsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<HealthBottle>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<Pistol>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<Rifles>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ShootGun>().AsSingle().NonLazy();
        }
    }
}