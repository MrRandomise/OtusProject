using UnityEngine;
using OtusProject.Content;
using Zenject;
using OtusProject.Player.Death;
using OtusProject.Config.Weapons;

namespace OtusProject.Visual
{
    public sealed class CharacterVisual : MonoBehaviour
    {
        [SerializeField] private CharacterInstaller _character;
        [SerializeField] private Animator _animator;
        private PlayerAnimatorController _characterAnimatorController;
        private DeathPlayer _deatPlayer;
        private BulletInitInEcsWorld _onBullet;

        [Inject]
        private void Construct(DeathPlayer deathPlayer, BulletInitInEcsWorld onBullet)
        {
            _deatPlayer = deathPlayer;
            _onBullet = onBullet;
        }

        private void Awake()
        {
            _characterAnimatorController = new PlayerAnimatorController(_character, _animator, _deatPlayer, _onBullet);
        }

        private void Update()
        {
            _characterAnimatorController.Update();
        }
    }
}