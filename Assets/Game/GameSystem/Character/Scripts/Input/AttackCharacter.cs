using OtusProject.Config.Weapons;
using Zenject;
using System;
using UnityEngine;
using OtusProject.Player;

namespace OtusProject.PlayerInput
{
    public sealed class AttackCharacter: ITickable
    {
        private Weapon _weapon;
        private float _currFireRate;
        private BulletInitInEcsWorld _bulletInstaller;
        public event Action OnReload;

        [Inject]
        private void Construct(Character character, BulletInitInEcsWorld bulletInstaller)
        {
            _weapon = character.CurrentWeapon;
            _currFireRate = _weapon.WeaponConfig.FireRate;
            _bulletInstaller = bulletInstaller;
        }

        public void Tick()
        {
            _currFireRate += Time.deltaTime;
        }

        public void AttackRequest()
        {
            if (_weapon.WeaponConfig.CurrAmmo > 0)
            {
                if (_currFireRate >= _weapon.WeaponConfig.FireRate)
                {
                    _weapon.WeaponConfig.CurrAmmo -= 1;
                    _currFireRate = 0;
                    _bulletInstaller.BulletInitial(_weapon);
                }
            }
            else
            {
                OnReload?.Invoke();
            }
        }
    }
}

