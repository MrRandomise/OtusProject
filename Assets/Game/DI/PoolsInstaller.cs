using OtusProject.Pools;
using OtusProject.Waves;
using UnityEngine;
using Zenject;

namespace OtusProject.Installer
{
    public sealed class PoolsInstaller : MonoInstaller
    {
        [SerializeField] private PoolZombieView _poolZombieView;
        [SerializeField] private WaveView _waveView;
        public override void InstallBindings()
        {
            Container.Bind<WaveView>().FromInstance(_waveView).AsSingle();
            Container.Bind<PoolZombieView>().FromInstance(_poolZombieView).AsSingle();
            Container.BindInterfacesAndSelfTo<WaveSystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PoolZombie>().AsSingle().NonLazy();
            Container.Bind<PoolSystem>().AsTransient();
        }
    }
}