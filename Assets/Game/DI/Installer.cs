using UnityEngine;
using Zenject;
using OtusProject.CoreCamera;
using OtusProject.Player;
using OtusProject.CoreInput;
using OtusProject.PlayerInput;
using OtusProject.Player.Hit;
using OtusProject.Player.Death;
using OtusProject.Visual;
using OtusProject.Content;

namespace OtusProject.Installer
{
    public sealed class Installer : MonoInstaller
    {
        [SerializeField] private Character _character;
        [SerializeField] private Camera _mainCamera;
        public override void InstallBindings()
        {
            Container.Bind<Character>().FromInstance(_character).AsSingle();
            Container.Bind<CharacterVisual>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<CharacterInputController>().AsSingle();
            Container.Bind<Camera>().FromInstance(_mainCamera).AsSingle();
            Container.BindInterfacesAndSelfTo<CameraController>().AsSingle();
            Container.Bind<PlayerHit>().AsSingle().NonLazy();
            Container.Bind<HitEvents>().FromComponentInHierarchy().AsSingle();
            Container.Bind<DeathPlayer>().AsSingle().NonLazy();
        }
    }
}
