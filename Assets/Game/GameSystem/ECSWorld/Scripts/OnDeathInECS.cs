using Leopotam.EcsLite.Entities;
using System;
using UnityEngine;

namespace OtusProject.ECSEvent
{
    public sealed class OnDeathInECS
    {
        public event Action<Entity, Transform> OnDeath;

        public void OnDeathEvent(Entity entity, Transform pos)
        {
            OnDeath?.Invoke(entity, pos);
        }
    }
}

