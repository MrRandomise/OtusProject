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

namespace OtusProject.Installer
{
    public sealed class Installer : MonoInstaller
    {
        [SerializeField] private CharacterInstaller _character;
        [SerializeField] private ResourcesTriggerEnter _resourcesHitEvent;
        public override void InstallBindings()
        {
            
            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
            Container.Bind<CharacterInstaller>().FromInstance(_character).AsSingle();
            Container.BindInterfacesAndSelfTo<CharacterDeathObserver>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerHealth>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CameraController>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<AttackController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MoveController>().AsSingle();
            Container.Bind<ResourcesStorage>().FromComponentInHierarchy().AsSingle();
            Container.Bind<EcsStartup>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<ResourcesTriggerEnter>().FromComponentInNewPrefab(_resourcesHitEvent).AsCached();
            Container.Bind<OnDeathInECS>().AsSingle();
            Container.Bind<OnHitInECS>().AsSingle();
            Container.Bind<OnDropInECS>().AsSingle();
            Container.Bind<ResourcesInstaler>().AsCached();
            Container.Bind<BulletInstaller>().AsCached();
            Container.Bind<ZombieInstaller>().AsCached();
        }
    }
}
