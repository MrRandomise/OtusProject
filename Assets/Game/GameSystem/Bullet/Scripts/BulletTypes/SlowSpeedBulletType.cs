using Leopotam.EcsLite.Entities;
using System;
using UnityEngine;
using OtusProject.Component;
using OtusProject.Component.Request;
namespace OtusProject.Effects
{
    [Serializable]
    public sealed class SlowSpeedBulletType : IEffects
    {
        [SerializeField] public string Name = "Speed";
        [SerializeField] public float SpeedRate;
        [SerializeField] public int Damage = 1;
        [SerializeField] public string Description = "Уменьшение скорости передвижения зомби на n";

        public void UseEffect(Entity entity)
        {
            entity.GetData<NavAgent>().Value.speed -= SpeedRate;
            if(entity.GetData<NavAgent>().Value.speed < 1)
            {
                entity.GetData<NavAgent>().Value.speed = 1;
            }
            entity.SetData(new DamageRequest { Value = Damage });
        }
    }
}