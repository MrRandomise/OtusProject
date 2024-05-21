using OtusProject.Content;
using UnityEngine;
using Zenject;

namespace OtusProject.Player.Hit
{
    public sealed class HitEvents : MonoBehaviour
    {
        private PlayerSetHealth _setHealth;
        [Inject]
        private void Construct(PlayerSetHealth setHealth)
        {
            _setHealth = setHealth;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                var damage = other.GetComponent<ZombieInstaller>().Damage;
                _setHealth.SetHealth(-damage);
            }
        }
    }
}