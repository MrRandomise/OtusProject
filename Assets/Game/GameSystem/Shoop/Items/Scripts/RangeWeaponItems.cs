using OtusProject.Config.Weapons;
using OtusProject.Content;
using OtusProject.PlayerInput;
using OtusProject.View;
using System;
using UnityEngine;
using Zenject;

namespace OtusProject.ItemSystem
{
    [Serializable]
    public sealed class RangeWeaponItems : IItems
    {
        [SerializeField] public RangeWeapon Weapon;
        [SerializeField] public ItemsView WeaponMenuPrefab;
        [SerializeField] public Sprite ItemIcon;
        private static CharacterInputController _characterInputController;
        private static AttackCharacter _attack;
        private static ReloadWeapon _reload;
        private static ChangeWeapon _change;
        private static CharacterInstaller _character;
        private static Transform _weaponContainer;
        private static Transform _weaponMenuContainer;
        private const int _alpha = 5;
        [Inject]
        private void Construct(CharacterInstaller character, CharacterInputController inputManager, AttackCharacter attack, ReloadWeapon reload, ChangeWeapon change)
        {
            _character = character;
            _attack = attack;
            _reload = reload;
            _change = change;
            _characterInputController = inputManager;
            _weaponContainer = GameObject.FindGameObjectWithTag("WeaponContainer").transform;
            _weaponMenuContainer = GameObject.FindGameObjectWithTag("WeaponContent").transform;
        }

        public void BuyItem()
        {
            var item = GameObject.Instantiate(Weapon, _weaponContainer.position, _weaponContainer.rotation, _weaponContainer);
            var menuPrefab = GameObject.Instantiate(WeaponMenuPrefab, WeaponMenuPrefab.transform.position, Quaternion.identity, _weaponMenuContainer);
            if (_character.CurrentWeapon != null)
            {
                _character.CurrentWeapon.GetConfig().View.OpacityItems();
                _character.CurrentWeapon.GetPrefab().gameObject.SetActive(false);
            }
            _character.ListWeapon.Add(Weapon.WeaponConfig.UseKey, item);
            _character.CurrentWeapon = item;
            _character.CurrentWeapon.GetPrefab().SetActive(true);
            _character.CurrentWeapon.Ininital(_characterInputController, _attack, _reload, _change);
            item.WeaponConfig.View = menuPrefab;
            menuPrefab.ItemIcon.sprite = ItemIcon;
            menuPrefab.ItemCount.text = item.WeaponConfig.MaxAmmo.ToString();
            menuPrefab.ItemMaxCount.text = item.WeaponConfig.MaxAmmo.ToString();
            menuPrefab.ItemIcon.sprite = ItemIcon;
            menuPrefab.Key.text = item.WeaponConfig.UseKey.ToString().Remove(0, _alpha);
        }

        public Sprite GetIcon()
        {
            return ItemIcon;
        }
    }
}

