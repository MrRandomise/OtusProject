using System;

namespace OtusProject.Component.Events
{
    [Serializable]
    public struct BulletHitEvent
    {
        public IEffects Value;
    }
}