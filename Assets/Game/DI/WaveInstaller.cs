using OtusProject.View;
using OtusProject.Waves;
using Zenject;

namespace OtusProject.Installer
{
    public sealed class WaveInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WaveTimer>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<WaveSystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<WaveMessagePresenter>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<StopWaveRule>().AsSingle().NonLazy();
            Container.Bind<ZombieDeathObserver>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<StartWaveRule>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<WaveViewPresenter>().AsSingle().NonLazy();


        }
    }
}