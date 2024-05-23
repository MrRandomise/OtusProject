using System;
using UnityEngine;
using Zenject;

namespace OtusProject.PlayerInput
{
    public enum UseKey
    {
        Stop,
        Fire,
        Move,
        ChangeWeapon
    }

    public sealed class InputManager : ITickable
    {
        public Action<UseKey> OnUseKey;
        public Action<KeyCode> OnKeyboard;
        private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));
        public void Tick()
        {
            if (Input.GetMouseButtonUp(0))
            {
                OnUseKey?.Invoke(UseKey.Fire);
            }
            if (Input.GetMouseButtonDown(1))
            {
                OnUseKey?.Invoke(UseKey.Move);
            }
            else if(Input.GetMouseButtonUp(1))
            {
                OnUseKey?.Invoke(UseKey.Stop);
            }
            if (Input.anyKey)
            {
                foreach (KeyCode keyCode in keyCodes)
                {
                    if (Input.GetKeyUp(keyCode))
                    {
                        OnKeyboard?.Invoke(keyCode);
                    }
                }
            }
        }
    }
}