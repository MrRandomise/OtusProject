using OtusProject.Content;
using System;
using UnityEngine;
using Zenject;

namespace OtusProject.PlayerInput
{
    public enum UseKey
    {
        Left,
        Right,
        Forward,
        Backward,
        Stop,
        Fire
    }

    public sealed class InputManager : ITickable
    {
        public Action<UseKey> OnUseKey;
        public Action<KeyCode> OnUseKeyboard;
        private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));
        private CharacterInstaller _character;
        InputManager(CharacterInstaller character)
        {
            _character = character;
        }

        public void Tick()
        {
            if (Input.GetMouseButtonUp(0))
            {
                if(!_character.JoystickInput)
                    OnUseKey?.Invoke(UseKey.Fire);
            }

            if (Input.GetKey(KeyCode.A))
            {
                OnUseKey?.Invoke(UseKey.Left);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                OnUseKey?.Invoke(UseKey.Right);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                OnUseKey?.Invoke(UseKey.Forward);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                OnUseKey?.Invoke(UseKey.Backward);
            }
            else
            {
                OnUseKey?.Invoke(UseKey.Stop);
            }
            if (!Input.GetMouseButtonUp(0) && !Input.GetMouseButtonDown(1) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                foreach (KeyCode keyCode in keyCodes)
                {
                    if (Input.GetKeyUp(keyCode))
                    {
                        OnUseKeyboard?.Invoke(keyCode);
                        break;
                    }
                }
            }
        }
    }
}