using OtusProject.Effects;
using OtusProject.Weapons;
using OtusProject.ItemSystem;
using OtusProject.View;
using Zenject;
using OtusProject.Inventary;
using OtusProject.WeaponComponents;
using OtusProject.PlayerInput;

namespace OtusProject.Installer
{
    public sealed class WeaponInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            Container.Bind<WeaponStorage>().AsSingle().NonLazy();
            Container.Bind<WeaponStoragePresenter>().AsSingle().NonLazy();
            Container.Bind<WeaponsBuyer>().AsSingle().NonLazy();
            Container.Bind<WeaponContainer>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<BleedingEffects>().AsCached().NonLazy();
            Container.BindInterfacesAndSelfTo<ReloadWeaponComponent>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<FireWeaponComponent>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ChangeWeaponController>().AsSingle().NonLazy();
            Container.Bind<ChangeWeaponComponent>().AsSingle().NonLazy();
            Container.Bind<AddWeaponToCharacterOnAwake>().FromComponentInHierarchy().AsSingle();
            


        }
    }
}