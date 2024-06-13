using Leopotam.EcsLite.Entities;
using System;
using UnityEngine;
using OtusProject.Component.Request;
namespace OtusProject.Effects
{
    [Serializable]
    public sealed class SlowingEffects : IEffects
    {
        [SerializeField] private string Name = "Slowing";
        [SerializeField] private float _speedRate = 1;
        [SerializeField] private int _damage = 1;
        [SerializeField] private string Description = "Уменьшение скорости передвижения зомби на n";

        public void UseEffect(Entity entity)
        {
            entity.SetData(new SlowingRequest { Damage = _damage, SpeedRate = _speedRate });
        }
    }
}