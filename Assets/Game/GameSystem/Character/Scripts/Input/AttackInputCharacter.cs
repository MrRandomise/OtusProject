using Zenject;
using System;
using UnityEngine;
using OtusProject.Player;
using OtusProject.Pools;

namespace OtusProject.PlayerInput
{
    public sealed class AttackInputCharacter: ITickable
    {
        private CharacterInstaller _character;
        private float _currFireRate = 0;
        public event Action OnReload;
        private PoolBulletSystem _poolBullet;

        [Inject]
        private void Construct(CharacterInstaller character, PoolBulletSystem poolBullet)
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
            if (_character.IsAlive)
            {
                if (_character.CurrentWeapon.GetConfig().CurrAmmo > 0)
                {
                    if (_currFireRate >= _character.CurrentWeapon.GetConfig().FireRate)
                    {
                        _poolBullet.BulletInitial(_character.CurrentWeapon);
                        _character.CurrentWeapon.GetConfig().CurrAmmo -= 1;
                        _currFireRate = 0;

                    }
                }
                else
                {
                    OnReload?.Invoke();
                }
            }
        }
    }
}

