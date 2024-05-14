using System;
using UnityEngine;
using OtusProject.CoreInput;
using OtusProject.Player;
using Zenject;


namespace OtusProject.PlayerInput
{
    public sealed class CharacterInputController : IDisposable, ITickable
    {
        private readonly InputManager _inputManager;
        private readonly Character _character;
        private UseKey _lastKey = UseKey.Stop;
        //private bool _fireRequired;

        public CharacterInputController(InputManager input, Character character)
        {
            _inputManager = input;
            _inputManager.OnUseKey += GetKey;
            _character = character;
        }

        private void GetKey(UseKey key)
        {
            //if (key == UseKey.Fire)
            //{
            //    _fireRequired = true;
            //}

            _lastKey = key;
        }

        public void Tick()
        {
            _character.MoveDirection = GetDirection();
            //if (_fireRequired)
            //{
            //    _fireRequired = false;
            //    _character.OnFireRequested?.Invoke();
            //}
        }

        public void Dispose()
        {
            _inputManager.OnUseKey -= GetKey;
        }

        private Vector3 GetDirection()
        {
            switch (_lastKey)
            {
                case UseKey.Left:
                    return -_character.transform.right;
                case UseKey.Right:
                    return _character.transform.right;
                case UseKey.Forward:
                    return _character.transform.forward;
                case UseKey.Backward:
                    return -_character.transform.forward;
                default:
                    return Vector3.zero;
            }
        }
    }
}

