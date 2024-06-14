using Zenject;
using System;
using UnityEngine;
using OtusProject.Player;
using OtusProject.Pools;
using OtusProject.Inventary;

namespace OtusProject.PlayerInput
{
    public sealed class AttackInputCharacter: ITickable, IDisposable
    {
        private CharacterInstaller _character;
        private WeaponInventory _inventary;
        private float _currFireRate = 0;
        public event Action OnReload;
        public event Action OnFire; 
        private PoolBulletSystem _poolBullet;
        private CharacterInputController _controller;

        [Inject]
        private void Construct(WeaponInventory inventory, CharacterInstaller character, PoolBulletSystem poolBullet, CharacterInputController controller)
        {
            _character = character;
            _inventary = inventory;
            _poolBullet = poolBullet;
            _controller = controller;
            _controller.OnFireRequest += AttackRequest;
        }

        public void Tick()
        {
            _currFireRate += Time.deltaTime;
        }

        public void AttackRequest()
        {
            if (_character.IsAlive)
            {
                var weapon = _inventary.GetActiveWeapon();
                if (weapon.WeaponConfig.CurrAmmo > 0)
                {
                    if (_currFireRate >= weapon.WeaponConfig.FireRate)
                    {
                        _poolBullet.BulletInitial();
                        weapon.WeaponConfig.CurrAmmo -= 1;
                        _currFireRate = 0;
                        OnFire?.Invoke();
                    }
                }
                else
                {
                    OnReload?.Invoke();
                }
            }
        }

        public void Dispose()
        {
            _controller.OnFireRequest -= AttackRequest;
        }
    }
}

