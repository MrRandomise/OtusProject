using OtusProject.PlayerInput;
using UnityEngine;

namespace OtusProject.Weapons
{
    public interface IWeapon
    {
        public void Attack();
        public void ChangeWeapon(IWeapon weapon);
        public WeaponConfig GetConfig();
        public GameObject GetPrefab();
        public BulletConfig GetBulletConfig();
        Transform GetBulletPoint();
        void Reload();
        void Ininital(CharacterInputController inputManager, AttackInputCharacter fire, ReloadWeapon reloadWeapon, ChangeWeapon change);
    }
}