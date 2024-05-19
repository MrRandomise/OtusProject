using UnityEngine;
using OtusProject.Player;
using Zenject;
using OtusProject.Player.Death;
using OtusProject.Config.Weapon;
using OtusProject.PlayerInput;

namespace OtusProject.Visual
{
    public sealed class CharacterVisual : MonoBehaviour
    {
        [SerializeField] private Character _character;
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