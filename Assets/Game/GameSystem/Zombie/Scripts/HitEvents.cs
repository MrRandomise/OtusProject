using OtusProject.Content;
using UnityEngine;
using System;
using Leopotam.EcsLite.Entities;

namespace OtusProject.Zombie.Hit
{
    public sealed class HitEvents : MonoBehaviour
    {
        [SerializeField]private ZombieInstaller _installer;
        public static event Action<int, Entity> OnHit;
        private int _damage;

        private void Start()
        {
            _damage = _installer.Damage;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && other.TryGetComponent(out Entity entity))
            {
                OnHit?.Invoke(-_damage, entity);
            }
        }
    }
}