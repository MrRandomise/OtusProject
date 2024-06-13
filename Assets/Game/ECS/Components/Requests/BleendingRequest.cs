using System;

namespace OtusProject.Component.Request
{
    [Serializable]
    public struct BleendingRequest
    {
        public int DamagePerSec;
        public float TotalTimer;
        public float FromTime;
        public float CurrentTimer;
    }
}