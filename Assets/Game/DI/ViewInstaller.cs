using OtusProject.Player;
using OtusProject.RecourcesConfig;
using OtusProject.View;
using Zenject;
using UnityEngine;

namespace OtusProject.Installer
{
    public sealed class ViewInstaller : MonoInstaller
    {
        [SerializeField] private ResourcesTriggerEnter _resourcesHitEvent;
        public override void InstallBindings()
        {
            Container.Bind<KillsView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<HealthView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<CoinView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<ResourcePresenter>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ZombieHealthBarPresenter>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<HealthPresenter>().AsSingle().NonLazy();
            Container.Bind<KillZombiePresenter>().AsSingle().NonLazy();
            Container.Bind<ResourcesTriggerEnter>().FromComponentInNewPrefab(_resourcesHitEvent).AsCached();
        }
    }
}