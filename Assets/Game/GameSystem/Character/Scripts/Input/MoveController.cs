using System;
using UnityEngine;
using Zenject;
using Leopotam.EcsLite.Entities;
using OtusProject.Component;
using OtusProject.Player;

namespace OtusProject.PlayerInput
{
    public sealed class MoveController : IDisposable, ITickable
    {
        private readonly InputManager _inputManager;
        private Entity _character;

        private UseKey _useKey = UseKey.Stop;

        public MoveController(InputManager input, CharacterInstaller character)
        {
            _inputManager = input;
            _inputManager.OnUseKey += GetKey;
            _character = character.GetComponent<Entity>();
        }

        public void GetKey(UseKey key)
        {
            _useKey = key;
        }
        public void Tick()
        {
            _character.GetData<MoveDirection>().Value = GetDirection();
        }

        private Vector3 GetDirection()
        {
            if (_character.GetData<IsLife>().Value && _character.GetData<CanMove>().Value)
            {
                switch (_useKey)
                {
                    case UseKey.Left:
                        Debug.Log("Test");
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
            return Vector3.zero;
        }

        public void Dispose()
        {
            _inputManager.OnUseKey -= GetKey;
        }
    }
}

