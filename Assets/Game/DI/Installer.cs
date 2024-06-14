using UnityEngine;
using Zenject;
using OtusProject.CoreCamera;
using OtusProject.Player;
using OtusProject.PlayerInput;
using OtusProject.GameOver;
using OtusProject.Content;
using EcsEngine;
using OtusProject.RecourcesConfig;
using OtusProject.ECSEvent;
using OtusProject.View;

namespace OtusProject.Installer
{
    public sealed class Installer : MonoInstaller
    {
        [SerializeField] private CharacterInstaller _character;
        public override void InstallBindings()
        {
            
            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
            Container.Bind<CharacterInstaller>().FromInstance(_character).AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverMenu>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverSystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerHealth>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CameraController>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<AttackInputCharacter>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CharacterInputController>().AsSingle();
            Container.BindInterfacesAndSelfTo<AtttackAnimator>().AsSingle().NonLazy();
            Container.Bind<ResourcesStorage>().FromComponentInHierarchy().AsSingle();
            Container.Bind<KillZombieManager>().AsSingle().NonLazy();
            Container.Bind<EcsStartup>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<OnDeathInECS>().AsSingle();
            Container.Bind<OnHitInECS>().AsSingle();
            Container.Bind<OnDropInECS>().AsSingle();
            Container.Bind<ResourcesInstaler>().AsCached();
            Container.Bind<BulletInstaller>().AsCached();
            Container.Bind<ZombieInstaller>().AsCached();



            //Container.Bind<FixedJoystick>().FromComponentInHierarchy().AsSingle();
            //Container.BindInterfacesAndSelfTo<JoystickInput>().AsSingle().NonLazy();
            //Container.Bind<JoystickAttack>().FromComponentInHierarchy().AsSingle();
        }
    }
}
