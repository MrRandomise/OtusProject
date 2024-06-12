using OtusProject.Player;
using Zenject;

namespace OtusProject.Weapons
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
            _character.CurrentWeapon.GetConfig().WeaponContent.OpacityItems();
            _character.CurrentWeapon.GetPrefab().SetActive(false);
            _character.CurrentWeapon = weapon;
            _character.CurrentWeapon.GetPrefab().SetActive(true);
            _character.CurrentWeapon.GetConfig().WeaponContent.ShowItems();
        }
    }
}