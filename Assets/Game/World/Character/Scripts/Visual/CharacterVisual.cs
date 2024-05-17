using UnityEngine;
using OtusProject.Player;
using Zenject;
using OtusProject.Player.Death;
using OtusProject.PlayerInput;
using OtusProject.PoolsSystem;

namespace OtusProject.Visual
{
    public sealed class CharacterVisual : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private Animator _animator;
        private PlayerAnimatorController _characterAnimatorController;
        private DeathPlayer _deatPlayer;
        private PoolsComponent _pool;

        [Inject]
        private void Construct(DeathPlayer deathPlayer, PoolsComponent pool)
        {
            _deatPlayer = deathPlayer;
            _pool = pool;
        }

        private void Awake()
        {
            _characterAnimatorController = new PlayerAnimatorController(_character, _animator, _deatPlayer, _pool);
        }

        private void Update()
        {
            _characterAnimatorController.Update();
        }
    }
}