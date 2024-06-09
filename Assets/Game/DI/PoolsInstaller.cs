using OtusProject.Content;
using OtusProject.Pools;
using OtusProject.RecourcesConfig;
using OtusProject.Waves;
using System.ComponentModel;
using UnityEngine;
using Zenject;

namespace OtusProject.Installer
{
    public sealed class PoolsInstaller : MonoInstaller
    {
        [SerializeField] private PoolZombieManager _poolZombieInstall;
        [SerializeField] private PoolBulletManager _poolBulletInstall;
        [SerializeField] private PoolResourcesManager _poolResourcesManager;
        [SerializeField] private WaveView _waveView;
        public override void InstallBindings()
        {
            Container.Bind<WaveView>().FromInstance(_waveView).AsSingle();
            Container.BindInterfacesAndSelfTo<SetPoolResources>().AsSingle().NonLazy();
            Container.Bind<PoolZombieManager>().FromInstance(_poolZombieInstall).AsSingle();
            Container.Bind<PoolBulletManager>().FromInstance(_poolBulletInstall).AsSingle();
            Container.Bind<PoolResourcesManager>().FromInstance(_poolResourcesManager).AsSingle();
            Container.BindInterfacesAndSelfTo<WaveSystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PoolZombieSystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PoolBulletSystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PoolResourcesSystem>().AsSingle().NonLazy();
            Container.Bind<BulletInstaller>().AsCached();
            Container.Bind<ZombieInstaller>().AsCached();
            Container.Bind<ResourcesInstaler>().AsCached();
        }
    }
}