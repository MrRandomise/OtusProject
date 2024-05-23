using OtusProject.View;
using UnityEngine;
using Zenject;

namespace OtusProject.Installer
{
    public sealed class ViewInstaller : MonoInstaller
    {
        [SerializeField] private ZombieView _zombieView;
        [SerializeField] private CoinView _coinView;
        [SerializeField] private WaveView _waveView;
        [SerializeField] private ItemsContentView _itemContent;
        [SerializeField] private ItemsView _itemView;
        public override void InstallBindings()
        {
            Container.Bind<ZombieView>().FromInstance(_zombieView).AsSingle();
            Container.Bind<CoinView>().FromInstance(_coinView).AsSingle();
            Container.Bind<WaveView>().FromInstance(_waveView).AsSingle();
            Container.Bind<ItemsContentView>().FromInstance(_itemContent).AsSingle();
            Container.Bind<ItemsView>().FromInstance(_itemView).AsSingle();
        }
    }
}