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
using OtusProject.Pools;
using OtusProject.ECSEvent;
using System.ComponentModel;
using OtusProject.View;

namespace OtusProject.Installer
{
    public sealed class Installer : MonoInstaller
    {
        [SerializeField] private CharacterInstaller _character;
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private GameOverMenu _gameOverMenu;

        public override void InstallBindings()
        {
            Container.Bind<RangeWeaponItems>().AsSingle().NonLazy();
            Container.Bind<Camera>().FromInstance(_mainCamera).AsSingle();
            Container.Bind<CharacterInstaller>().FromInstance(_character).AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverMenu>().FromInstance(_gameOverMenu).AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverSystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerSetHealth>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CameraController>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<AttackInputCharacter>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ReloadWeapon>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CharacterInputController>().AsSingle();
            Container.BindInterfacesAndSelfTo<ChangeViewWeapon>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<HealthBottle>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<RangeWeapon>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ClickWeaponChange>().AsSingle().NonLazy();
            Container.Bind<ChangeWeapon>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BloodBullet>().AsCached().NonLazy();
            Container.Bind<EcsStartup>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<OnDeathInECS>().AsSingle();
            Container.Bind<OnHitInECS>().AsSingle();
            Container.Bind<KillZombieView>().AsSingle().NonLazy();
            Container.Bind<ResourcesStorage>().FromComponentInHierarchy().AsSingle().NonLazy();


            //Container.Bind<FixedJoystick>().FromComponentInHierarchy().AsSingle();
            //Container.BindInterfacesAndSelfTo<JoystickInput>().AsSingle().NonLazy();
            //Container.Bind<JoystickAttack>().FromComponentInHierarchy().AsSingle();
        }
    }
}
