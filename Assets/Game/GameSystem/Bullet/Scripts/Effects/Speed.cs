using Leopotam.EcsLite.Entities;
using OtusProject.Component.Zombie;
using System;
using UnityEngine;
namespace OtusProject.Config.Effects
{
    [Serializable]
    public sealed class Speed : IEffects
    {
        [SerializeField] public string Name = "Speed";
        [SerializeField] public float SpeedRate;
        [SerializeField] public int Damage = 1;
        [SerializeField] public string Description = "Уменьшение скорости передвижения зомби на n";

        public void UseEffect(Entity entity)
        {
            entity.GetData<ZombieNavAgent>().Value.speed -= SpeedRate;
            if(entity.GetData<ZombieNavAgent>().Value.speed < 1)
            {
                entity.GetData<ZombieNavAgent>().Value.speed = 1;
            }
            entity.SetData(new DamageRequest { Value = Damage });
        }
    }
}