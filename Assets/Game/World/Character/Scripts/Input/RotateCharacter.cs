using OtusProject.Player;
using UnityEngine;

namespace OtusProject.PlayerInput
{
    public sealed class RotateCharacter
    {
        private Vector3 _previousMousePosition;
        private Character _character;
        private readonly Camera _camera;

        public RotateCharacter(Character character)
        {
            _previousMousePosition = Input.mousePosition;
            _character = character;
            _camera = Camera.main;
        }

        public void Update()
        {
            if (!_character.IsAlive)
                return;
            var mousePosition = Input.mousePosition;
            if (mousePosition != _previousMousePosition)
            {
                if (Physics.Raycast(GetMouseRay(), out var hit))
                {
                    _character.transform.LookAt(new Vector3(hit.point.x, _character.transform.position.y, hit.point.z));
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