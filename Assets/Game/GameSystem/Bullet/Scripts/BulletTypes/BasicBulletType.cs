using Leopotam.EcsLite.Entities;
using OtusProject.Component.Request;
using System;
using UnityEngine;
namespace OtusProject.Effects
{
    [Serializable]
    public sealed  class BasicBulletType : IEffects
    {
        [SerializeField] public string Name = "Basic";
        [SerializeField] public int Damage = 1;
        [SerializeField] public string Description = "Базовая пуля";
        public void UseEffect(Entity entity)
        {
            entity.SetData(new DamageRequest { Value = Damage });
        }
    }
}