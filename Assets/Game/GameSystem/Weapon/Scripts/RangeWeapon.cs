using OtusProject.PlayerInput;
using OtusProject.Weapons;
using System;
using UnityEngine;

namespace OtusProject.Config.Weapons
{
    public sealed class RangeWeapon : MonoBehaviour, IWeapon, IDisposable
    {
        public WeaponConfig WeaponConfig;
        public BulletConfig BulletConfig;
        public Transform BulletPoint;

        private CharacterInputController InputManager;
        private AttackInputCharacter Fire;
        private ReloadWeapon ReloadWeapon;
        private ChangeWeapon Change;

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
            Fire.AttackRequest();
        }

        public void ChangeWeapon(IWeapon weapon)
        {
            Change.Change(weapon);
        }

        public void Reload()
        {
            ReloadWeapon.Reload();
        }

        public Transform GetBulletPoint()
        {
            return BulletPoint;
        }

        public void Ininital(CharacterInputController inputManager, AttackInputCharacter fire, ReloadWeapon reloadWeapon, ChangeWeapon change)
        {
            InputManager = inputManager;
            Fire = fire;
            ReloadWeapon = reloadWeapon;
            Change = change;
            InputManager.OnFireRequest += Attack;
            Fire.OnReload += Reload;
            InputManager.OnChangeWeapon += ChangeWeapon;
        }

        public void Dispose()
        {
            InputManager.OnFireRequest += Attack;
            Fire.OnReload += Reload;
            InputManager.OnChangeWeapon += ChangeWeapon;
        }
    }
}
