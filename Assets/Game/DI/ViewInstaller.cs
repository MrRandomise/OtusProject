using OtusProject.View;
using UnityEngine;
using Zenject;

namespace OtusProject.Installer
{
    public class ViewInstaller : MonoInstaller
    {
        [SerializeField] private StartVaweButton _startVaweButton;

        public override void InstallBindings()
        {
            Container.Bind<StartVaweButton>().FromInstance(_startVaweButton).AsSingle();
        }
    }
}