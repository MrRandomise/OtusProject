using UnityEngine;
using OtusProject.Player;

namespace OtusProject.Visual
{
    public sealed class CharacterVisual : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private Animator _animator;
        //[SerializeField] private AnimatorDispatcher _dispatcher;
        private PlayerAnimatorController _characterAnimatorController;

        private void Awake()
        {
            _characterAnimatorController = new PlayerAnimatorController(_character, _animator);
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