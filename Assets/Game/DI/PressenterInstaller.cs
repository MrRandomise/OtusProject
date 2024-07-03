using OtusProject.Player;
using OtusProject.RecourcesConfig;
using OtusProject.View;
using OtusProject.Weapons;
using Zenject;

public class PressenterInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<WeaponViewPresenter>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<ResourcePresenter>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<ZombieHealthBarPresenter>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<HealthPresenter>().AsSingle().NonLazy();
        Container.Bind<KillZombiePresenter>().AsSingle().NonLazy();
    }
}