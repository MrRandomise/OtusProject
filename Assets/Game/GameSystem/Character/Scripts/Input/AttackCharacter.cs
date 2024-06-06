using OtusProject.Config.Weapons;
using Zenject;
using System;
using UnityEngine;
using OtusProject.Content;

namespace OtusProject.PlayerInput
{
    public sealed class AttackCharacter: ITickable
    {
        private CharacterInstaller _character;
        private float _currFireRate = 0;
        private BulletInitInEcsWorld _bulletInstaller;
        public event Action OnReload;

        [Inject]
        private void Construct(CharacterInstaller character, BulletInitInEcsWorld bulletInstaller)
        {
            _character = character;
            _bulletInstaller = bulletInstaller;
        }

        public void Tick()
        {
            _currFireRate += Time.deltaTime;
        }

        public void AttackRequest()
        {
            //if (_character.CurrentWeapon.GetConfig().CurrAmmo > 0)
            //{
            //    if (_currFireRate >= _character.CurrentWeapon.GetConfig().FireRate)
            //    {
            //        _character.CurrentWeapon.GetConfig().CurrAmmo -= 1;
            //        _currFireRate = 0;
            //        _bulletInstaller.BulletInitial(_character.CurrentWeapon);
            //    }
            //}
            //else
            //{
            //    OnReload?.Invoke();
            //}
        }
    }
}

