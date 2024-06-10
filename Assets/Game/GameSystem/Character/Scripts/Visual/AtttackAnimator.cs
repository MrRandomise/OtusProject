using Leopotam.EcsLite.Entities;
using OtusProject.PlayerInput;
using OtusProject.Component.Events;
using System;

namespace OtusProject.Player
{
    public class AtttackAnimator : IDisposable
    {
        private Entity _installer;
        private AttackInputCharacter _attackInputCharacter;
        AtttackAnimator(CharacterInstaller installer, AttackInputCharacter attackInputCharacter)
        {
            _installer = installer.GetComponent<Entity>();
            _attackInputCharacter = attackInputCharacter;
            _attackInputCharacter.OnFire += Attack;
        }

        private void Attack()
        {
            _installer.SetData(new AttackEvent());
        }

        public void Dispose()
        {
            _attackInputCharacter.OnFire -= Attack;
        }
    }
}