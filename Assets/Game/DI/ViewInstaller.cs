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
        [SerializeField] private CoinView _coinView;
        [SerializeField] private WaveView _waveView;
        [SerializeField] private HealthView _healthView;
        [SerializeField] private ItemsContentView _itemContent;
        [SerializeField] private ItemsView _itemView;
        [SerializeField] private Transform _mapSpawn;
        public override void InstallBindings()
        {
            Container.Bind<Transform>().FromInstance(_mapSpawn).AsSingle();
            Container.Bind<ZombieView>().FromInstance(_zombieView).AsSingle();
            Container.Bind<CoinView>().FromInstance(_coinView).AsSingle();
            Container.Bind<WaveView>().FromInstance(_waveView).AsSingle();
            Container.Bind<HealthView>().FromInstance(_healthView).AsSingle();
            Container.Bind<ItemsContentView>().FromInstance(_itemContent).AsSingle();
            Container.Bind<ItemsView>().FromInstance(_itemView).AsSingle();
            Container.BindInterfacesAndSelfTo<HealthUpdate>().AsSingle().NonLazy();
        }
    }
}