using UnityEngine;
using Zenject;

namespace OtusProject.PlayerInput
{
    public sealed class JoystickAttack : MonoBehaviour
    {
        private CharacterInputController _controller;

        [Inject]
        void construct (CharacterInputController controller)
        {
            _controller = controller;
        }

        public void AttackButton()
        {
            _controller.GetKey(UseKey.Fire);
        }

    }
}

