using OtusProject.Pools;
using UnityEngine;
using Zenject;

namespace OtusProject.Installer
{
    public sealed class PoolsInstaller : MonoInstaller
    {
        [SerializeField] private PoolZombieManager _poolZombieInstall;
        [SerializeField] private PoolBulletManager _poolBulletInstall;
        public override void InstallBindings()
        {
            Container.Bind<PoolZombieManager>().FromInstance(_poolZombieInstall).AsSingle();
            Container.Bind<PoolBulletManager>().FromInstance(_poolBulletInstall).AsSingle();
            Container.Bind<PoolResourcesManager>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<PoolZombieSystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PoolBulletSystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PoolResourcesSystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PoolInitializeSpawnZombie>().AsSingle().NonLazy();
        }
    }
}