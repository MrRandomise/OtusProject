using UnityEngine;

namespace OtusGame.Core
{
    interface IInputManager
    {
        Vector3 Movement(Transform direction, float speed);
        Transform Rotation(Transform direction, Transform target, float speed);
    }
}

