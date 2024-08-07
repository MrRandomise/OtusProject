using OtusProject.Inventary;
using UnityEngine;
using Zenject;
namespace OtusProject.Weapons
{
    public sealed class AddWeaponToCharacterOnAwake : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;
        private WeaponStorage _weaponStorage;

        [Inject]
        private void Construct(WeaponStorage weaponStorage)
        {
            _weaponStorage = weaponStorage;
        }

        private void Awake()
        {
            _weaponStorage.AddWeapon(_weapon, _weapon.WeaponConfig.UseKey);
        }
    }
}

