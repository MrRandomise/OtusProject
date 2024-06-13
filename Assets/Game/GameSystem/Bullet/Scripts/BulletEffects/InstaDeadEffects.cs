using Leopotam.EcsLite.Entities;
using OtusProject.Component.Request;
using OtusProject.Component;
using System;
using UnityEngine;
namespace OtusProject.Effects
{
    [Serializable]
    public sealed class InstaDeadEffects : IEffects
    {
        [SerializeField] public string Name = "Instant Death";
        [SerializeField] public string Description = "Мгновненное убийство";
        public void UseEffect(Entity entity)
        {
            entity.SetData(new DamageRequest { Value = entity.GetData<MaxHealth>().Value });
        }
    }
}