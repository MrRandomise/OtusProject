using Leopotam.EcsLite.Entities;
using UnityEngine;
using OtusProject.Component.Zombie;


namespace OtusProject.Content
{
    public class ZombieInstaller : EntityInstaller
    {
        [SerializeField] private int _health;
        protected override void Install(Entity entity)
        {
            entity.AddData(new ZombieHealth { value = _health });
        }

        protected override void Dispose(Entity entity)
        {

        }
    }
}
