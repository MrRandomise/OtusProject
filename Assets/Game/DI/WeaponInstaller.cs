using OtusProject.Effects;
using OtusProject.Weapons;
using OtusProject.ItemSystem;
using OtusProject.View;
using Zenject;

namespace OtusProject.Installer
{
    public sealed class WeaponInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<WeaponsItem>().AsSingle().NonLazy();
            Container.Bind<WeaponContainer>().FromComponentInHierarchy().AsSingle();
            Container.Bind<WeaponPanel>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IWeapon>().To<RangeWeapon>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<BleedingEffects>().AsCached().NonLazy();
            Container.BindInterfacesAndSelfTo<ReloadWeapon>().AsSingle().NonLazy();
            Container.Bind<ChangeWeapon>().AsSingle().NonLazy();
        }
    }
}