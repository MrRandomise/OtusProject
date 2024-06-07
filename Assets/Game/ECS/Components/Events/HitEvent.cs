using System;
using Leopotam.EcsLite.Entities;
namespace OtusProject.Component.Events
{
    [Serializable]
    public struct HitEvent
    {
        public IEffects Effect;
        public Entity target;
    }
}