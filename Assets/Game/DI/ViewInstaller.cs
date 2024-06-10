using OtusProject.Config.Weapons;
using OtusProject.Player;
using OtusProject.RecourcesConfig;
using OtusProject.View;
using Zenject;

namespace OtusProject.Installer
{
    public sealed class ViewInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ZombieView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<HealthView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<SetViewResources>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ZombieHealthBarUpdate>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ChangeViewWeapon>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<AtttackAnimator>().AsSingle().NonLazy();
            Container.Bind<UpdateViewHealth>().AsSingle().NonLazy();
            Container.Bind<KillZombieManager>().AsSingle().NonLazy();
            Container.Bind<KillZombieView>().AsSingle().NonLazy();
            Container.Bind<ClickWeaponChange>().AsSingle().NonLazy();
            Container.Bind<ChangeWeapon>().AsSingle().NonLazy();
        }
    }
}