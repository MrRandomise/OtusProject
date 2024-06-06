using OtusProject.Content;
using System;
using UnityEngine;
using Zenject;

namespace OtusProject.Config.Weapons
{
    public class ReloadWeapon : ITickable
    {
        private CharacterInstaller _character;
        private float _currTimer = 0;
        private float _reloadTimer;
        private bool _startTimer = false;
        public static event Action OnStopReload;

        [Inject]
        private void Construct(CharacterInstaller character)
        {
            _character = character;
        }

        public void Tick()
        {
            //if(_startTimer)
            //{
            //    _currTimer += Time.deltaTime;
            //    if(_currTimer > _reloadTimer)
            //    {
            //        _character.CurrentWeapon.GetConfig().CurrAmmo = _character.CurrentWeapon.GetConfig().MaxAmmo;
            //        _startTimer = false;
            //        OnStopReload?.Invoke();
            //    }
            //}
        }

        public void Reload() 
        {
            //if(!_startTimer)
            //{
            //    _reloadTimer = _character.CurrentWeapon.GetConfig().ReloadTime;
            //    _currTimer = 0;
            //    _startTimer = true;
            //}
        }
    }
}