using OtusProject.Player;
using OtusProject.PlayerInput;
using System;
using UnityEngine;
using Zenject;

namespace OtusProject.Weapons
{
    public sealed class RangeWeapon : MonoBehaviour, IWeapon, IDisposable
    {
        public WeaponConfig WeaponConfig;
        public BulletConfig BulletConfig;
        public Transform BulletPoint;

        private CharacterInputController _inputManager;
        private AttackInputCharacter _fire;
        private ReloadWeapon _reloadWeapon;
        private ChangeWeapon _change;

        public WeaponConfig GetConfig()
        {
            return WeaponConfig;
        }

        public BulletConfig GetBulletConfig()
        {
            return BulletConfig;
        }

        public GameObject GetPrefab()
        {
            return gameObject;
        }

        public void Attack()
        {
            _fire.AttackRequest();
        }

        public void ChangeWeapon(IWeapon weapon)
        {
            _change.Change(weapon);
        }

        public void Reload()
        {
            _reloadWeapon.Reload();
        }

        public Transform GetBulletPoint()
        {
            return BulletPoint;
        }

        public void Ininital(CharacterInputController inputManager, AttackInputCharacter fire, ReloadWeapon reloadWeapon, ChangeWeapon change)
        {
            _inputManager = inputManager;
            _fire = fire;
            _reloadWeapon = reloadWeapon;
            _change = change;
            _inputManager.OnFireRequest += Attack;
            _fire.OnReload += Reload;
            _inputManager.OnChangeWeapon += ChangeWeapon;
        }

        public void Dispose()
        {
            _inputManager.OnFireRequest += Attack;
            _fire.OnReload += Reload;
            _inputManager.OnChangeWeapon += ChangeWeapon;
        }
    }
}
