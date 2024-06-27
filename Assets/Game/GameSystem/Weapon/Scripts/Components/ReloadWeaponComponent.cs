using OtusProject.Inventary;
using Zenject;
using System;
using UnityEngine;

namespace OtusProject.WeaponComponents
{
    public sealed class ReloadWeaponComponent : ITickable
    {
        private WeaponStorage _weapon;
        public event Action OnStopReload;
        private float _currTimer = 0;
        private float _reloadTimer;
        private bool _startTimer = false;

        ReloadWeaponComponent(WeaponStorage inventory)
        {
            _weapon = inventory;
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

        public void ReloadRequest()
        {
            if (!_startTimer)
            {
                var weapon = _weapon.GetActiveWeapon();
                _reloadTimer = weapon.WeaponConfig.ReloadTime;
                _currTimer = 0;
                _startTimer = true;
            }
        }
    }
}
