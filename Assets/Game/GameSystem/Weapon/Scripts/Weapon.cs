using OtusProject.Player;
using OtusProject.PlayerInput;
using OtusProject.Weapons;
using System;
using UnityEngine;
using Zenject;

namespace OtusProject.Config.Weapons
{
    public sealed class Weapon : MonoBehaviour, IWeapon, IRangeWeapon, IDisposable
    {
        public WeaponConfig WeaponConfig;
        public BulletConfig BulletConfig;
        public Transform BulletPoint;
        public bool Active;
        private Character _character;
        private CharacterInputController _inputManager;
        private AttackCharacter _attackCharacter;
        private ReloadWeapon _reloadWeapon;

        [Inject]
        private void Construct(CharacterInputController inputManager, Character character, AttackCharacter attackCharacter, ReloadWeapon reloadWeapon)
        {
            _character = character;
            _inputManager = inputManager;
            _attackCharacter = attackCharacter;
            _reloadWeapon = reloadWeapon;
            _inputManager.OnFireRequest += Attack;
            _attackCharacter.OnReload += Reload;
            _inputManager.OnChangeWeapon += ChangeWeapon;
        }

        public void Attack()
        {
            _attackCharacter.AttackRequest();
        }

        public void ChangeWeapon(KeyCode code)
        {
            if(WeaponConfig.UseKey == code.ToString())
            {
                _character.CurrentWeapon.Active = false;
                _character.CurrentWeapon.gameObject.SetActive(false);
                _character.CurrentWeapon = this;
                _character.CurrentWeapon.gameObject.SetActive(true);
            }
        }

        public void Reload()
        {
            _reloadWeapon.Reload();
        }

        public void Dispose()
        {
            _inputManager.OnFireRequest -= Attack;
            _attackCharacter.OnReload -= Reload;
            _inputManager.OnChangeWeapon -= ChangeWeapon;
            _inputManager.OnChangeWeapon -= ChangeWeapon;
        }
    }
}
