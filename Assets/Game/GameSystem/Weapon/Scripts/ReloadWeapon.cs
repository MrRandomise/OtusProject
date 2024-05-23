using OtusProject.Player;
using OtusProject.PlayerInput;
using System;
using UnityEngine;
using Zenject;

namespace OtusProject.Config.Weapons
{
    public class ReloadWeapon : ITickable
    {
        private WeaponConfig _weaponConfig;
        private float _currTimer = 0;
        private float _reloadTimer;
        private bool _startTimer = false;
        public event Action OnStopReload;

        [Inject]
        private void Construct(Character character)
        {
            _weaponConfig = character.CurrentWeapon.WeaponConfig;
            _reloadTimer = _weaponConfig.ReloadTime;
        }

        public void Tick()
        {
            if(_startTimer)
            {
                _currTimer += Time.deltaTime;
                if(_currTimer > _reloadTimer)
                {
                    _weaponConfig.CurrAmmo = _weaponConfig.MaxAmmo;
                    _startTimer = false;
                    OnStopReload?.Invoke();
                }
            }
        }

        public void Reload() 
        {
            if(!_startTimer)
            {
                _currTimer = 0;
                _startTimer = true;
            }
        }
    }
}