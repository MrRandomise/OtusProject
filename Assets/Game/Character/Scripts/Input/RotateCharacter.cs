using UnityEngine;

namespace OtusProject.PlayerInput
{
    public sealed class RotateCharacter
    {
        private Vector3 _previousMousePosition;
        private readonly bool _isAlive;
        private readonly Transform _targetTransform;
        private readonly Camera _camera;

        public RotateCharacter(bool isAlive, Transform targetTransform)
        {
            _previousMousePosition = Input.mousePosition;
            _isAlive = isAlive;
            _targetTransform = targetTransform;
            _camera = Camera.main;
        }

        public void Update()
        {
            if (!_isAlive)
                return;
            var mousePosition = Input.mousePosition;
            if (mousePosition != _previousMousePosition)
            {
                if (Physics.Raycast(GetMouseRay(), out var hit))
                {
                    _targetTransform.LookAt(new Vector3(hit.point.x, _targetTransform.position.y, hit.point.z));
                    _previousMousePosition = mousePosition;
                }
            }
        }

        private Ray GetMouseRay()
        {
            return _camera.ScreenPointToRay(Input.mousePosition);
        }
    }
}