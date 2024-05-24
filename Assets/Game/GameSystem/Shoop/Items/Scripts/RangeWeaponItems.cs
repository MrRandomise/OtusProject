using OtusProject.Config.Weapons;
using OtusProject.Player;
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
        [SerializeField] public Transform WeaponContainer;
        [SerializeField] public Transform WeaponMenuContainer;
        [SerializeField] public ItemsView WeaponMenuPrefab;
        [SerializeField] public Sprite ItemIcon;
        private static CharacterInputController _characterInputController;
        private static AttackCharacter _attack;
        private static ReloadWeapon _reload;
        private static ChangeWeapon _change;

        private static Character _character;

        [Inject]
        private void Construct(Character character, CharacterInputController inputManager, AttackCharacter attack, ReloadWeapon reload, ChangeWeapon change)
        {
            _character = character;
            _attack = attack;
            _reload = reload;
            _change = change;
            _characterInputController = inputManager;
        }

        public void BuyItem()
        {
            Debug.Log("Купили оружие!");
            var item = GameObject.Instantiate(Weapon, WeaponContainer.transform.position, WeaponContainer.transform.rotation, WeaponContainer);
            var menuPrefab = GameObject.Instantiate(WeaponMenuPrefab, WeaponMenuPrefab.transform.position, Quaternion.identity, WeaponMenuContainer);
            if(_character.CurrentWeapon != null)
            {
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
        }

        public Sprite GetIcon()
        {
            return ItemIcon;
        }
    }
}

