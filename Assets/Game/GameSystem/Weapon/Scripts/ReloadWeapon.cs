using System;
using Zenject;
using UnityEngine;
using OtusProject.Inventary;
using OtusProject.PlayerInput;

namespace OtusProject.Weapons
{
    public sealed class ReloadWeapon : ITickable, IDisposable
    {
        private WeaponInventory _weapon;
        private float _currTimer = 0;
        private float _reloadTimer;
        private bool _startTimer = false;
        public  event Action OnStopReload;
        public AttackInputCharacter _attackCharacter;
        [Inject]
        private void Construct(WeaponInventory inventory, AttackInputCharacter attackInputCharacter)
        {
            _weapon = inventory;
            _attackCharacter = attackInputCharacter;
            _attackCharacter.OnReload += Reload;
        }

        public void Tick()
        {
            if (_startTimer)
            {
                _currTimer += Time.deltaTime;
                if (_currTimer > _reloadTimer)
                {
                    var weapon = _weapon.GetActiveWeapon();
                    weapon.WeaponConfig.CurrAmmo = weapon.WeaponConfig.MaxAmmo;
                    _startTimer = false;
                    OnStopReload?.Invoke();
                }
            }
        }

        public void Reload()
        {
            if (!_startTimer)
            {
                var weapon = _weapon.GetActiveWeapon();
                _reloadTimer = weapon.WeaponConfig.ReloadTime;
                _currTimer = 0;
                _startTimer = true;
            }
        }

        public void Dispose()
        {
            _attackCharacter.OnReload -= Reload;
        }
    }
}