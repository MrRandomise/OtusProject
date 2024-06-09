using Leopotam.EcsLite.Entities;
using System;

namespace OtusProject.ECSEvent
{
    public sealed class OnHitInECS
    {
        public event Action<Entity> OnDeath;

        public void OnHitEvent(Entity entity)
        {
            OnDeath?.Invoke(entity);
        }
    }
}