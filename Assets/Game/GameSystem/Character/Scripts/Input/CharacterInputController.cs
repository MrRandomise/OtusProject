using System;
using UnityEngine;
using OtusProject.Player;
using Zenject;


namespace OtusProject.PlayerInput
{
    public sealed class CharacterInputController : IDisposable, ITickable
    {
        private readonly InputManager _inputManager;
        private readonly Character _character;
        private UseKey _lastKey = UseKey.Stop;
        public event Action OnFireRequest;

        public CharacterInputController(InputManager input, Character character)
        {
            _inputManager = input;
            _inputManager.OnUseKey += GetKey;
            _character = character;
        }

        private void GetKey(UseKey key)
        {
            if (key == UseKey.Fire)
            {
                OnFireRequest?.Invoke();
            }
            _lastKey = key; 
        }

        public void Tick()
        {
            _character.MoveDirection = GetDirection();
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
