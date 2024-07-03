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
    }

    public sealed class InputManager : ITickable
    {
        public Action<UseKey> OnUseKey;
        public Action<KeyCode> OnUseKeyNum;
        public Action OnFire;
        public void Tick()
        {
            if (Input.GetMouseButtonUp(0))
            {
                OnFire?.Invoke();
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
            else if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                OnUseKeyNum?.Invoke(KeyCode.Alpha0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                OnUseKeyNum?.Invoke(KeyCode.Alpha1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                OnUseKeyNum?.Invoke(KeyCode.Alpha2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                OnUseKeyNum?.Invoke(KeyCode.Alpha3);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                OnUseKeyNum?.Invoke(KeyCode.Alpha4);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                OnUseKeyNum?.Invoke(KeyCode.Alpha5);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                OnUseKeyNum?.Invoke(KeyCode.Alpha6);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                OnUseKeyNum?.Invoke(KeyCode.Alpha7);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                OnUseKeyNum?.Invoke(KeyCode.Alpha8);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                OnUseKeyNum?.Invoke(KeyCode.Alpha9);
            }
            else
            {
                OnUseKey?.Invoke(UseKey.Stop);
            }
        }
    }
}