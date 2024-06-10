using OtusProject.Player;
using OtusProject.PlayerInput;
using System;

namespace OtusProject.Config.Weapons
{
    public sealed class ChangeViewWeapon : IDisposable
    {
        private CharacterInstaller _character;
        private ReloadWeapon _reloadWeapon;
        private AttackInputCharacter _attack;

        ChangeViewWeapon(CharacterInstaller character, ReloadWeapon reloadWeapon, AttackInputCharacter attack)
        {
            _character = character;
            _attack = attack;
            _attack.OnFire += ChangeAmmoView;
            _reloadWeapon = reloadWeapon;
            _reloadWeapon.OnStopReload += ChangeAmmoView;
        }

        private void ChangeAmmoView()
        {
            _character.CurrentWeapon.GetConfig().View.ItemCount.text = _character.CurrentWeapon.GetConfig().CurrAmmo.ToString();
            _character.CurrentWeapon.GetConfig().View.ItemMaxCount.text = _character.CurrentWeapon.GetConfig().MaxAmmo.ToString();
        }

        public void Dispose()
        {
            _attack.OnFire -= ChangeAmmoView;
            _reloadWeapon.OnStopReload -= ChangeAmmoView;
        }
    }
}