using OtusProject.Config.Weapons;
using Zenject;
using System;
using UnityEngine;
using OtusProject.Content;
using OtusProject.Pools;

namespace OtusProject.PlayerInput
{
    public sealed class AttackCharacter: ITickable
    {
        private CharacterInstaller _character;
        private float _currFireRate = 0;
        public event Action OnReload;
        private PoolBullet _poolBullet;

        [Inject]
        private void Construct(CharacterInstaller character, PoolBullet poolBullet)
        {
            _character = character;
            _poolBullet = poolBullet;
        }

        public void Tick()
        {
            _currFireRate += Time.deltaTime;
        }

        public void AttackRequest()
        {
            if (_character.CurrentWeapon.GetConfig().CurrAmmo > 0)
            {
                if (_currFireRate >= _character.CurrentWeapon.GetConfig().FireRate)
                {
                    _character.CurrentWeapon.GetConfig().CurrAmmo -= 1;
                    _currFireRate = 0;
                    _poolBullet.BulletInitial(_character.CurrentWeapon);
                }
            }
            else
            {
                OnReload?.Invoke();
            }
        }
    }
}

