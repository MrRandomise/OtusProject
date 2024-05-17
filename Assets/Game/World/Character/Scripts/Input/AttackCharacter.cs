using OtusProject.Config.Weapon;
using Zenject;
using System;
using UnityEngine;
using OtusProject.Player;
using OtusProject.PoolsSystem;
using OtusProject.BulletSystem;

namespace OtusProject.PlayerInput
{
    public sealed class AttackCharacter: IDisposable, ITickable
    {
        private CharacterInputController _charInput;
        private Weapon _weapon;
        private float _currFireRate;
        private PoolsComponent _pool;
        [Inject]
        private void Construct(Character character, CharacterInputController charInput, PoolsComponent pool)
        {
            _weapon = character.CurrentWeapon;
            _charInput = charInput;
            _charInput.OnFireRequest += AttackRequest;
            _currFireRate = _weapon.WeaponConfig.FireRate;
            _pool = pool;
        }

        public void Tick()
        {
            _currFireRate += Time.deltaTime;
        }

        public void AttackRequest()
        {
            if (_currFireRate >= _weapon.WeaponConfig.FireRate && _weapon.WeaponConfig.CurrAmmo > 0)
            {
                _weapon.WeaponConfig.CurrAmmo -= 1;
                _currFireRate = 0;
                var bullet = _pool.GetOrCreateBullet(_weapon.WeaponConfig.Bullet, _weapon.BulletPoint);
                var installer = bullet.GetComponent<BulletData>();
                installer.BulletConfig = _weapon.BulletConfig;
                installer.BulletPool = _weapon.BullePool;
            }
        }

        public void Dispose()
        {
            _charInput.OnFireRequest -= AttackRequest;
        }
    }
}

