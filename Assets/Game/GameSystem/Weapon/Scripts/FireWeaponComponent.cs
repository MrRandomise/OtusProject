using Leopotam.EcsLite.Entities;
using OtusProject.Component;
using OtusProject.Component.Events;
using OtusProject.Inventary;
using OtusProject.Player;
using OtusProject.Pools;
using UnityEngine;
using Zenject;

namespace OtusProject.WeaponComponents
{
    public sealed class FireWeaponComponent : ITickable
    {
        private Entity _character;
        private WeaponStorage _inventary;
        private PoolBulletSystem _poolBullet;
        private float _currFireRate = 0;

        FireWeaponComponent(WeaponStorage inventory, PoolBulletSystem poolBullet, CharacterInstaller character)
        {
            _inventary = inventory;
            _poolBullet = poolBullet;
            _character = character.GetComponent<Entity>();
        }

        public void Tick()
        {
            _currFireRate += Time.deltaTime;
        }

        public bool TryAttack(out int ammo)
        {
            var weapon = _inventary.GetActiveWeapon();
            if (_character.GetData<IsLife>().Value && _character.GetData<CanMove>().Value)
            {
                if (weapon.WeaponConfig.CurrAmmo > 0)
                {
                    if (_currFireRate >= weapon.WeaponConfig.FireRate)
                    {
                        _poolBullet.BulletInitial();
                        weapon.WeaponConfig.CurrAmmo -= 1;
                        _currFireRate = 0;
                        _character.SetData(new AttackEvent());
                        ammo = weapon.WeaponConfig.CurrAmmo;
                        return true;
                    }
                }
            }
            ammo = weapon.WeaponConfig.CurrAmmo;
            return false;
        }
    }
}