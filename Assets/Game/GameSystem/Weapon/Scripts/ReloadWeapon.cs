using OtusProject.Player;
using System;
using UnityEngine;
using Zenject;

namespace OtusProject.Config.Weapons
{
    public class ReloadWeapon : ITickable
    {
        private Character _character;
        private float _currTimer = 0;
        private float _reloadTimer;
        private bool _startTimer = false;
        public event Action OnStopReload;

        [Inject]
        private void Construct(Character character)
        {
            _character = character;
        }

        public void Tick()
        {
            if(_startTimer)
            {
                _currTimer += Time.deltaTime;
                if(_currTimer > _reloadTimer)
                {
                    _character.CurrentWeapon.GetConfig().CurrAmmo = _character.CurrentWeapon.GetConfig().MaxAmmo;
                    _startTimer = false;
                    OnStopReload?.Invoke();
                }
            }
        }

        public void Reload() 
        {
            if(!_startTimer)
            {
                _reloadTimer = _character.CurrentWeapon.GetConfig().ReloadTime;
                _currTimer = 0;
                _startTimer = true;
            }
        }
    }
}