using UnityEngine;
using OtusProject.Player;
using Zenject;
using Leopotam.EcsLite.Entities;
using OtusProject.Component;

namespace OtusProject.PlayerInput
{
    public sealed  class JoystickInput: ITickable
    {
        private FixedJoystick _variableJoystick;
        private Entity _character;
        private CharacterInstaller _characterInstaller;
        JoystickInput(FixedJoystick variableJoystick, CharacterInstaller character, CharacterInstaller characterInstaller)
        {
            _variableJoystick = variableJoystick;
            _character = character.GetComponent<Entity>();
            _characterInstaller = characterInstaller;
        }

        public void Tick()
        {
            if (_characterInstaller.CanMove)
            {
                _character.GetData<MoveDirection>().Value += Vector3.forward * _variableJoystick.Vertical + Vector3.right * _variableJoystick.Horizontal;
            }
        }
    }
}

