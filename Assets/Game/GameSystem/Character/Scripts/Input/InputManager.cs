using System;
using UnityEngine;
using Zenject;

namespace OtusProject.PlayerInput
{
    public enum UseKey
    {
        Stop,
        Fire,
        Move
    }

    public sealed class InputManager : ITickable
    {
        public Action<UseKey> OnUseMouse;
        public Action<KeyCode> OnUseKeyboard;
        private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));
        public void Tick()
        {
            if (Input.GetMouseButtonUp(0))
            {
                OnUseMouse?.Invoke(UseKey.Fire);
            }
            if (Input.GetMouseButtonDown(1))
            {
                OnUseMouse?.Invoke(UseKey.Move);
            }
            else if(Input.GetMouseButtonUp(1))
            {
                OnUseMouse?.Invoke(UseKey.Stop);
            }
            if (Input.anyKey && !Input.GetMouseButtonUp(0) && !Input.GetMouseButtonDown(1))
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