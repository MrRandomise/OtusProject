using OtusProject.View;
using OtusProject.Waves;
using Zenject;

namespace OtusProject.Installer
{
    public sealed class WaveInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WaveSystem>().AsSingle().NonLazy();
            Container.Bind<WaveManager>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<NewWave>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<WaveViewUpdate>().AsSingle().NonLazy();
            Container.Bind<WaveView>().FromComponentInHierarchy().AsSingle();
        }
    }
}