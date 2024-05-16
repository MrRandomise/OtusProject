using UnityEngine;
using OtusProject.Player;
using Zenject;
using OtusProject.Player.Death;

namespace OtusProject.Visual
{
    public sealed class CharacterVisual : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private Animator _animator;
        //[SerializeField] private AnimatorDispatcher _dispatcher;
        private PlayerAnimatorController _characterAnimatorController;
        private DeathPlayer _deatPlayer;

        [Inject]
        private void Construct(DeathPlayer deathPlayer)
        {
            _deatPlayer = deathPlayer;
        }

        private void Awake()
        {
            _characterAnimatorController = new PlayerAnimatorController(_character, _animator, _deatPlayer);
        }

        //private void OnEnable()
        //{
        //    _characterAnimatorController.OnEnable();
        //}

        //private void OnDisable()
        //{
        //    _characterAnimatorController.OnDisable();
        //}

        private void Update()
        {
            _characterAnimatorController.Update();
        }
    }
}