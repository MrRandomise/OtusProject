using OtusProject.Player;

namespace OtusProject.ItemSystem
{
    public sealed class Pistol 
    {
        private Character _character;

        private void Construct(Character character)
        {
            _character = character;
        }

        public void UseItem()
        {
            //var weapon = Instantiate(this);
            //weapon.transform.SetParent(_character.WeaponPoint);
            //_character.CurrentWeapon = weapon;
        }
    }
}

