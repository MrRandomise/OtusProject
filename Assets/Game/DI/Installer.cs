using UnityEngine;
using Zenject;
using OtusProject.CoreCamera;
using OtusProject.Player;
using OtusProject.PlayerInput;
using OtusProject.Config.Weapons;
using OtusProject.GameOver;
using OtusProject.ItemSystem;
using OtusProject.Config.Effects;
using OtusProject.Content;
using EcsEngine;
using OtusProject.RecourcesConfig;
using OtusProject.ECSEvent;
using OtusProject.View;

namespace OtusProject.Installer
{
    public sealed class Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<RangeWeaponItems>().AsSingle().NonLazy();
            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
            Container.Bind<CharacterInstaller>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverMenu>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverSystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerSetHealth>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CameraController>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<AttackInputCharacter>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CharacterInputController>().AsSingle();
            Container.BindInterfacesAndSelfTo<HealthBottle>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<RangeWeapon>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<BloodBullet>().AsCached().NonLazy();
            Container.BindInterfacesAndSelfTo<ReloadWeapon>().AsSingle().NonLazy();
            Container.Bind<EcsStartup>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<OnDeathInECS>().AsSingle();
            Container.Bind<OnHitInECS>().AsSingle();
            Container.Bind<OnDropInECS>().AsSingle();
            Container.Bind<ResourcesInstaler>().AsCached();
            Container.Bind<BulletInstaller>().AsCached();
            Container.Bind<ZombieInstaller>().AsCached();
            Container.Bind<ResourcesStorage>().FromComponentInHierarchy().AsSingle();


            //Container.Bind<FixedJoystick>().FromComponentInHierarchy().AsSingle();
            //Container.BindInterfacesAndSelfTo<JoystickInput>().AsSingle().NonLazy();
            //Container.Bind<JoystickAttack>().FromComponentInHierarchy().AsSingle();
        }
    }
}
