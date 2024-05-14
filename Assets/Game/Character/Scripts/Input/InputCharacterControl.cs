using UnityEngine;
using Zenject;

namespace OtusGame.Core
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

    sealed public class InputCharacterControl: ITickable
    {
        private UseKey _lastKey = UseKey.Stop;
        private IInputManager _inputManager;

        public void Tick()
        {
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