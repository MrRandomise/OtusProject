using OtusProject.Player;
using System;
using UnityEngine;
using Zenject;

namespace OtusProject.ItemSystem
{
    [Serializable]
    public sealed class Pistol : IItems
    {
        private static Character _character;

        [Inject]
        private void Construct(Character character)
        {
            _character = character;
        }

        public void BuyItem()
        {
            Debug.Log("Куплен пистолет!");
            //var weapon = Instantiate(this);
            //weapon.transform.SetParent(_character.WeaponPoint);
            //_character.CurrentWeapon = weapon;
        }
    }
}

