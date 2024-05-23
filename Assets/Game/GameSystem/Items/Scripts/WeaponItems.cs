using System;
using UnityEngine;

namespace OtusProject.ItemSystem
{
    [Serializable]
    public sealed class WeaponItems : IItems
    {
        [SerializeField] public GameObject Weapon;
        [SerializeField] public Transform WeaponContainer;

        public void BuyItem()
        {
            Debug.Log("Купили оружие!");
            var item = GameObject.Instantiate(Weapon, WeaponContainer.transform.position, Quaternion.identity, WeaponContainer);
        }
    }
}

