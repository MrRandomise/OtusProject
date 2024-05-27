using Leopotam.EcsLite.Entities;
using OtusProject.Component.Zombie;
using System;
using UnityEngine;
namespace OtusProject.Config.Effects
{
    [Serializable]
    public sealed class InstantDeath : IEffects
    {
        [SerializeField] public string Name = "Instant Death";
        [SerializeField] public string Description = "Мгновненное убийство";
        public void UseEffect(Entity entity)
        {
            entity.SetData(new DamageRequest { Value = entity.GetData<ZombieHealth>().Value });
        }
    }
}