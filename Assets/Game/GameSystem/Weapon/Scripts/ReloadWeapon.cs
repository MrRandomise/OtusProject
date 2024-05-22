using OtusProject.Player;
using OtusProject.PlayerInput;
using System;
using UnityEngine;
using Zenject;

namespace OtusProject.Config.Weapons
{
    public class ReloadWeapon : ITickable, IDisposable
    {
        private WeaponConfig _weaponConfig;
        private float _currTimer = 0;
        private float _reloadTimer;
        private bool _startTimer = false;
        private AttackCharacter _attacker;
        public  event Action OnReload;

        [Inject]
        private void Construct(Character character, AttackCharacter attacker)
        {
            _weaponConfig = character.CurrentWeapon.WeaponConfig;
            _attacker = attacker;
            _reloadTimer = _weaponConfig.ReloadTime;
            _attacker.OnReload += Reload;
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
                    OnReload?.Invoke();
                }
            }
        }

        private void Reload() 
        {
            if(!_startTimer)
            {
                _currTimer = 0;
                _startTimer = true;
            }
        }

        public void Dispose()
        {
            _attacker.OnReload -= Reload;
        }
    }
}