using UnityEngine;
using OtusProject.Player;
using Zenject;

namespace OtusProject.PlayerInput
{
    public sealed  class JoystickInput: ITickable
    {
        private FixedJoystick _variableJoystick;
        private Character _character;

        JoystickInput(FixedJoystick variableJoystick, Character character)
        {
            _variableJoystick = variableJoystick;
            _character = character;
        }

        public void Tick()
        {
            if (_character.CanMove)
            {
                _character.MoveDirection += Vector3.forward * _variableJoystick.Vertical + Vector3.right * _variableJoystick.Horizontal;
            }
        }
    }
}

