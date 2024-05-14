using UnityEngine;

namespace OtusGame.Core
{
    sealed public class InputManager: IInputManager
    {
        public Vector3 Movement(Transform direction, float speed)
        {
            return speed * Time.deltaTime * direction.position;
        }

        public Transform Rotation(Transform direction, Transform target, float speed)
        {
            var rotation = Quaternion.LookRotation(direction.position);
            direction.rotation = Quaternion.Lerp(target.rotation, rotation, Time.deltaTime * speed);
            return direction;
        }
    }
}
