using Leopotam.EcsLite.Entities;
using System;

namespace OtusProject.ECSEvent
{
    public sealed class OnHitInECS
    {
        public event Action<Entity> OnHitEvents;

        public void HitEvent(Entity entity)
        {
            OnHitEvents?.Invoke(entity);
        }
    }
}