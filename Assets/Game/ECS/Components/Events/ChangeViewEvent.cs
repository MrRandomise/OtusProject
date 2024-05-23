using System;

namespace OtusProject.Component.Events
{
    [Serializable]
    public struct ChangeViewEvent
    {
        public int Value;
        public int ViewValue;

    }
}