using System;

namespace OtusProject.Component.Events
{
    [Serializable]
    public struct HitEvent
    {
        public IEffects Value;
    }
}