using Leopotam.EcsLite.Entities;
using OtusProject.Component.Request;
using System;
using UnityEngine;
namespace OtusProject.Config.Effects
{
    [Serializable]
    public sealed  class BasicBullet : IEffects
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