using OtusProject.View;
using Zenject;
using UnityEngine;

namespace OtusProject.Installer
{
    public sealed class ViewInstaller : MonoInstaller
    {
        [SerializeField] private WeaponPanel _weaponPanel;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameOverMenu>().FromComponentInHierarchy().AsSingle();
            Container.Bind<WeaponPanel>().FromComponentInNewPrefab(_weaponPanel).AsCached();
            Container.Bind<KillsView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<HealthView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<CoinView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<WaveView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<WaveTextView>().FromComponentInHierarchy().AsSingle();

        }
    }
}