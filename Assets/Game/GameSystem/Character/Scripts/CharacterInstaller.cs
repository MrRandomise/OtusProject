using Leopotam.EcsLite.Entities;
using OtusProject.Component;
using UnityEngine;

namespace OtusProject.Player
{
    public class CharacterInstaller : EntityInstaller
    {
        public int Health = 5;
        public float Speed;
        public float SpeedRotate;
        public bool CanMove = true;
        public bool IsAlive = true;
        public bool JoystickInput = false;
        public Vector3 MoveDirection;
        public Animator Animator;

        protected override void Install(Entity entity)
        {
            entity.AddData(new MaxHealth { Value = Health });
            entity.AddData(new CurrentHealth { Value = Health });
            entity.AddData(new CurrentEntity { Value = entity });
            entity.AddData(new Speed { Value = Speed });
            entity.AddData(new RotateSpeed { Value = SpeedRotate });
            entity.AddData(new CurrentTransform { Value = transform });
            entity.AddData(new MoveDirection { Value = MoveDirection});
            entity.AddData(new MainCamera { Value = Camera.main });
            entity.AddData(new MousePosition { Value = Input.mousePosition });
            entity.AddData(new ObjectAnimator { Value = Animator });
            entity.AddData(new CharacterTag());
        }

        protected override void Dispose(Entity entity)
        {

        }
    }
}