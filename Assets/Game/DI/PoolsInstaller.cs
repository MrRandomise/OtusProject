using OtusProject.Content;
using OtusProject.Pools;
using OtusProject.Waves;
using System.ComponentModel;
using UnityEngine;
using Zenject;

namespace OtusProject.Installer
{
    public sealed class PoolsInstaller : MonoInstaller
    {
        [SerializeField] private PoolZombieView _poolZombieInstall;
        [SerializeField] private PoolBulletView _poolBulletInstall;
        [SerializeField] private WaveView _waveView;
        public override void InstallBindings()
        {
            Container.Bind<WaveView>().FromInstance(_waveView).AsSingle();
            Container.Bind<PoolZombieView>().FromInstance(_poolZombieInstall).AsSingle();
            Container.Bind<PoolBulletView>().FromInstance(_poolBulletInstall).AsSingle();
            Container.BindInterfacesAndSelfTo<WaveSystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PoolZombie>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PoolBullet>().AsSingle().NonLazy();
            Container.Bind<BulletInstaller>().AsCached();
            Container.Bind<ZombieInstaller>().AsCached();
        }
    }
}