using Leopotam.EcsLite.Entities;
using OtusProject.Component.Request;
using System;
using UnityEngine;

namespace OtusProject.Effects
{
    [Serializable]
    public sealed class BleedingEffects : IEffects
    {
        [SerializeField] private string _name = "Blood";
        [SerializeField] private int _damagePerSec = 1;
        [SerializeField] private float _timer = 3;
        [SerializeField] private string _description = "Нанесение x урона в секунду n секунд";

        public void UseEffect(Entity entity)
        {
            if(!entity.TryGetData(out BleendingRequest data))
            {
                entity.SetData(new BleendingRequest { DamagePerSec = _damagePerSec, TotalTimer = _timer, CurrentTimer = 1, FromTime = 1 });
            }
        }
    }
}