using OtusProject.View;
using OtusProject.Waves;
using Zenject;

namespace OtusProject.Installer
{
    public sealed class WaveInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Wave>().AsSingle().NonLazy();
            Container.Bind<WaveTextView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<WaveMessagePresenter>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<StopWave>().AsSingle().NonLazy();
            Container.Bind<ZombieDeathObserver>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<StartWave>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<WaveViewPresenter>().AsSingle().NonLazy();
            Container.Bind<WaveView>().FromComponentInHierarchy().AsSingle();  
        }
    }
}