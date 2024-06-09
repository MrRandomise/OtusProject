using OtusProject.Player;
using OtusProject.Weapons;
using Zenject;

namespace OtusProject.Config.Weapons
{
    public sealed class ChangeWeapon 
    {
        private CharacterInstaller _character;

        [Inject]
        private void Construct(CharacterInstaller character)
        {
            _character = character;
        }

        public void Change(IWeapon weapon)
        {
            //_character.CurrentWeapon.GetConfig().View.OpacityItems();
            //_character.CurrentWeapon.GetPrefab().SetActive(false);
            //_character.CurrentWeapon = weapon;
            //_character.CurrentWeapon.GetPrefab().SetActive(true);
            //_character.CurrentWeapon.GetConfig().View.ShowItems();
        }
    }
}