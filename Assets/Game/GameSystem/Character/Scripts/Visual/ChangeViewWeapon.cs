using OtusProject.Player;
using OtusProject.PlayerInput;
using System;
using Zenject;
namespace OtusProject.Config.Weapons
{
    public sealed class ChangeViewWeapon : IDisposable
    {
        private Character _character;
        private BulletInitInEcsWorld _attack;

        [Inject]
        private void Construct(Character character, BulletInitInEcsWorld attack)
        {
            _character = character;
            _attack = attack;
            _attack.OnBulletEvent += ChangeAmmoView;
        }

        private void ChangeAmmoView()
        {
            _character.CurrentWeapon.GetConfig().View.ItemCount.text = _character.CurrentWeapon.GetConfig().CurrAmmo.ToString();
            _character.CurrentWeapon.GetConfig().View.ItemMaxCount.text = _character.CurrentWeapon.GetConfig().MaxAmmo.ToString();
        }

        public void Dispose()
        {
            _attack.OnBulletEvent -= ChangeAmmoView;
        }
    }
}