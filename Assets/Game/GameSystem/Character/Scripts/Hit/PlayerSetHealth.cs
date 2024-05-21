using System;
using Zenject;

namespace OtusProject.Player
{
    public sealed class PlayerSetHealth 
    {
        private Character _character;
        public event Action OnSetHealth;

        [Inject]
        private void Construct(Character character)
        {
            _character = character;
        }

        public void SetHealth(int damage)
        {
            _character.Health += damage;
            //OnSetHealth?.Invoke();
        }
    }
}