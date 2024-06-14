using OtusProject.Effects;
using OtusProject.Weapons;
using OtusProject.ItemSystem;
using OtusProject.View;
using Zenject;
using OtusProject.Inventary;

namespace OtusProject.Installer
{
    public sealed class WeaponInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<WeaponInventory>().AsSingle().NonLazy();
            Container.Bind<WeaponInventoryView>().AsSingle().NonLazy();
            Container.Bind<WeaponsBuyer>().AsSingle().NonLazy();
            Container.Bind<WeaponContainer>().FromComponentInHierarchy().AsSingle();
            Container.Bind<WeaponPanel>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<BleedingEffects>().AsCached().NonLazy();
            Container.BindInterfacesAndSelfTo<ReloadWeapon>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ChangeViewWeapon>().AsSingle().NonLazy();
            Container.Bind<ChangeWeapon>().AsSingle().NonLazy();
            Container.Bind<AddWeapon>().FromComponentInHierarchy().AsSingle();
            


        }
    }
}