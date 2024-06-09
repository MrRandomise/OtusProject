using OtusProject.Player;
using System;
using Zenject;
namespace OtusProject.Config.Weapons
{
    public sealed class ChangeViewWeapon : IDisposable
    {
        private CharacterInstaller _character;

        [Inject]
        private void Construct(CharacterInstaller character)
        {
            _character = character;
            //_attack = attack;
            //_attack.OnBulletEvent += ChangeAmmoView;
            ReloadWeapon.OnStopReload += ChangeAmmoView;
        }

        private void ChangeAmmoView()
        {
            //_character.CurrentWeapon.GetConfig().View.ItemCount.text = _character.CurrentWeapon.GetConfig().CurrAmmo.ToString();
            //_character.CurrentWeapon.GetConfig().View.ItemMaxCount.text = _character.CurrentWeapon.GetConfig().MaxAmmo.ToString();
        }

        public void Dispose()
        {
            //_attack.OnBulletEvent -= ChangeAmmoView;
            ReloadWeapon.OnStopReload -= ChangeAmmoView;
        }
    }
}