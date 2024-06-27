using OtusProject.Effects;
using OtusProject.Weapons;
using OtusProject.ItemSystem;
using OtusProject.View;
using Zenject;
using UnityEngine;
using OtusProject.Inventary;
using OtusProject.WeaponComponents;
using OtusProject.PlayerInput;

namespace OtusProject.Installer
{
    public sealed class WeaponInstaller : MonoInstaller
    {
        [SerializeField] private WeaponPanel _weaponPanel;
        public override void InstallBindings()
        {
            Container.Bind<WeaponStorage>().AsSingle().NonLazy();
            Container.Bind<WeaponStoragePresenter>().AsSingle().NonLazy();
            Container.Bind<WeaponPanel>().FromComponentInNewPrefab(_weaponPanel).AsCached();
            Container.Bind<WeaponsBuyer>().AsSingle().NonLazy();
            Container.Bind<WeaponContainer>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<BleedingEffects>().AsCached().NonLazy();
            Container.BindInterfacesAndSelfTo<ReloadWeaponComponent>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<FireWeaponComponent>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ChangeWeaponController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<WeaponViewPresenter>().AsSingle().NonLazy();
            Container.Bind<ChangeWeaponComponent>().AsSingle().NonLazy();
            Container.Bind<AddWeapon>().FromComponentInHierarchy().AsSingle();
            


        }
    }
}