using System;

namespace OtusProject.Component.Request
{
    [Serializable]
    public struct SlowingRequest
    {
        public int Damage;
        public float SpeedRate;
    }
}