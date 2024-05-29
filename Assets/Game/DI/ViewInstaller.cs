using OtusProject.RecourcesConfig;
using OtusProject.View;
using OtusProject.Visual;
using UnityEngine;
using Zenject;

namespace OtusProject.Installer
{
    public sealed class ViewInstaller : MonoInstaller
    {
        [SerializeField] private ZombieView _zombieView;
        [SerializeField] private WaveView _waveView;
        [SerializeField] private HealthView _healthView;
        [SerializeField] private ItemsContentView _itemContent;
        [SerializeField] private ItemsView _itemView;
        public override void InstallBindings()
        {
            Container.Bind<ZombieView>().FromInstance(_zombieView).AsSingle();
            Container.Bind<WaveView>().FromInstance(_waveView).AsSingle();
            Container.Bind<HealthView>().FromInstance(_healthView).AsSingle();
            Container.Bind<ItemsContentView>().FromInstance(_itemContent).AsSingle();
            Container.Bind<ItemsView>().FromInstance(_itemView).AsSingle();
            Container.BindInterfacesAndSelfTo<HealthUpdate>().AsSingle().NonLazy();
        }
    }
}