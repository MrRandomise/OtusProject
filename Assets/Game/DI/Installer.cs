using UnityEngine;
using Zenject;
using OtusProject.CoreCamera;
using OtusProject.Player;
using OtusProject.PlayerInput;
using OtusProject.Player.Death;
using OtusProject.Visual;
using OtusProject.Config.Weapons;
using OtusProject.Content;
using OtusProject.View;
using OtusProject.GameOver;
using OtusProject.ItemSystem;
using OtusProject.Config.Effects;

namespace OtusProject.Installer
{
    public sealed class Installer : MonoInstaller
    {
        [SerializeField] private Character _character;
        [SerializeField] private BulletSpawnInstaller _bulletSpawner;
        [SerializeField] private SpawnInstaller _spawnZombie;
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private GameOverMenu _gameOverMenu;

        public override void InstallBindings()
        {
            Container.Bind<RangeWeaponItems>().AsSingle().NonLazy();
            Container.Bind<Camera>().FromInstance(_mainCamera).AsSingle();
            Container.Bind<Character>().FromInstance(_character).AsSingle();
            Container.Bind<BulletSpawnInstaller>().FromInstance(_bulletSpawner).AsSingle();
            Container.Bind<SpawnInstaller>().FromInstance(_spawnZombie).AsSingle();
            Container.Bind<FixedJoystick>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverMenu>().FromInstance(_gameOverMenu).AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverSystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerSetHealth>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CameraController>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<AttackCharacter>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ReloadWeapon>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CharacterInputController>().AsSingle();
            Container.BindInterfacesAndSelfTo<DeathPlayer>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ChangeViewWeapon>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<HealthBottle>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<RangeWeapon>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<JoystickInput>().AsSingle().NonLazy();
            Container.Bind<JoystickAttack>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ClickWeaponChange>().AsSingle().NonLazy();
            Container.Bind<ChangeWeapon>().AsSingle().NonLazy();
            Container.Bind<CharacterVisual>().AsSingle();
            Container.Bind<BulletInitInEcsWorld>().AsSingle().NonLazy();
            Container.Bind<StartVawe>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<Blood>().AsCached().NonLazy();
        }
    }
}
