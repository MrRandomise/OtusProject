using Leopotam.EcsLite.Entities;
using UnityEngine;
using System;

namespace OtusProject.ECSEvent
{
    public sealed class OnDropInECS
    {
        public event Action<Entity, Transform> OnDrop;

        public void OnDropEvent(Entity entity, Transform pos)
        {
            OnDrop?.Invoke(entity, pos);
        }
    }
}