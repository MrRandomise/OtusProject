using OtusProject.Config.Effects;
using OtusProject.Config.Weapons;
using OtusProject.ItemSystem;
using OtusProject.View;
using Zenject;

namespace OtusProject.Installer
{
    public sealed class WeaponInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<RangeWeaponItems>().AsSingle().NonLazy();
            Container.Bind<WeaponContainer>().FromComponentInHierarchy().AsSingle();
            Container.Bind<WeaponPanel>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<RangeWeapon>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<BloodBullet>().AsCached().NonLazy();
            Container.BindInterfacesAndSelfTo<ReloadWeapon>().AsSingle().NonLazy();
            Container.Bind<ChangeWeapon>().AsSingle().NonLazy();
            Container.Bind<ClickWeaponChange>().AsSingle().NonLazy();
        }
    }
}