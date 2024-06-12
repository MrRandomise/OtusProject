using OtusProject.Player;
using OtusProject.PlayerInput;
using OtusProject.View;
using OtusProject.Weapons;
using System;
using UnityEngine;
using Zenject;

namespace OtusProject.ItemSystem
{
    [Serializable]
    public sealed class WeaponsItem : IProduct
    {
        [SerializeField] public RangeWeapon Weapon;
        [SerializeField] public WeaponPanel WeaponMenuPrefab;
        [SerializeField] public Sprite ItemIcon;
        [SerializeField] public Transform WeaponContainer;
        [SerializeField] public Transform WeaponMenuContainer;

        private static CharacterInputController _inputManager;
        private static CharacterInstaller _characterInstaller;
        private static AttackInputCharacter _fire;
        private static ReloadWeapon _reloadWeapon;
        private static ChangeWeapon _change;

        private const int _alpha = 5;

        [Inject]
        private void Construct(CharacterInstaller character, CharacterInputController inputManager, AttackInputCharacter attack, ReloadWeapon reload, ChangeWeapon change)
        {
            _characterInstaller = character;
            _fire = attack;
            _reloadWeapon = reload;
            _change = change;
            _inputManager = inputManager;
        }

        public void BuyItem()
        {
            var weapon = AddWeapon();
            var view = AddViewWeapon();
            InitialWeapon(weapon);
            ChangeViewWeapon(weapon, view);
        }

        private RangeWeapon AddWeapon() => GameObject.Instantiate(Weapon, WeaponContainer.position, WeaponContainer.rotation, WeaponContainer);

        private WeaponPanel AddViewWeapon() => GameObject.Instantiate(WeaponMenuPrefab, WeaponMenuPrefab.transform.position, Quaternion.identity, WeaponMenuContainer);

        private void ChangeViewWeapon(RangeWeapon weapon, WeaponPanel view)
        {
            weapon.WeaponConfig.WeaponContent = view;
            view.ItemIcon.sprite = ItemIcon;
            view.ItemCount.text = weapon.WeaponConfig.MaxAmmo.ToString();
            view.ItemMaxCount.text = weapon.WeaponConfig.MaxAmmo.ToString();
            view.ItemIcon.sprite = ItemIcon;
            view.Key.text = weapon.WeaponConfig.UseKey.ToString().Remove(0, _alpha);
        }

        public void InitialWeapon(RangeWeapon weapon)
        {
            if (_characterInstaller.CurrentWeapon != null)
            {
                _characterInstaller.CurrentWeapon.GetConfig().WeaponContent.OpacityItems();
                _characterInstaller.CurrentWeapon.GetPrefab().gameObject.SetActive(false);
            }
            _characterInstaller.ListWeapon.Add(weapon.WeaponConfig.UseKey, weapon);
            _characterInstaller.CurrentWeapon = weapon;
            _characterInstaller.CurrentWeapon.GetPrefab().SetActive(true);
            _characterInstaller.CurrentWeapon.Ininital(_inputManager, _fire, _reloadWeapon, _change);
        }

        public Sprite GetIcon()
        {
            return ItemIcon;
        }
    }
}

