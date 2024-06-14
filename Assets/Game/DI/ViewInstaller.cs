using OtusProject.Player;
using OtusProject.RecourcesConfig;
using OtusProject.View;
using Zenject;
using UnityEngine;

namespace OtusProject.Installer
{
    public sealed class ViewInstaller : MonoInstaller
    {
        [SerializeField] private ResourcesHitEvent _resourcesHitEvent;
        public override void InstallBindings()
        {
            Container.Bind<KillsView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<HealthView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<CoinView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<SetViewResources>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ZombieHealthBarUpdate>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<UpdateViewHealth>().AsSingle().NonLazy();
            Container.Bind<KillZombieView>().AsSingle().NonLazy();
            Container.Bind<ResourcesHitEvent>().FromComponentInNewPrefab(_resourcesHitEvent).AsCached();
        }
    }
}