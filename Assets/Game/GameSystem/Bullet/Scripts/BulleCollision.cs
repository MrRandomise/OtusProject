using UnityEngine;
using System;
using Leopotam.EcsLite.Entities;
using OtusProject.Component.Events;
using OtusProject.Component.Bullet;

namespace OtusProject.Content
{
    public sealed class BulleCollision : MonoBehaviour
    {
        [SerializeField] private Entity _bulletInstaller;
        public static event Action<Entity> OnBulletHit;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Zombie" && other.TryGetComponent(out Entity entity))
            {
                var effect = _bulletInstaller.GetData<BulletEffects>().Value;
                entity.AddData(new HitEvent { Effect = effect, target = entity, Bullet = _bulletInstaller } );
                OnBulletHit?.Invoke(_bulletInstaller);
            }
        }
    }
}
