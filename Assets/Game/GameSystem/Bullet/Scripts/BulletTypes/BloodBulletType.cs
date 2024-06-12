using Leopotam.EcsLite.Entities;
using OtusProject.Component.Request;
using System;
using UnityEngine;
using Zenject;

namespace OtusProject.Effects
{
    [Serializable]
    public sealed class BloodBulletType : IEffects, ITickable
    {
        [SerializeField] public string Name = "Blood";
        [SerializeField] public int DamagePerSec = 1;
        [SerializeField] public float Timer = 3;
        [SerializeField] public string Description = "Нанесение x урона в секунду n секунд";
        private static Entity _entity;
        private static bool _startTimer = false;
        private static int _currIteration = 0;
        private static float _currTimer = 1;
        private float _oneSecond = 1;

        public void UseEffect(Entity entity)
        {
            _entity = entity;
            _startTimer = true;
        }

        public bool TakeDamage()
        {
            _currIteration++;
            _entity.SetData(new DamageRequest { Value = DamagePerSec });
            if (_currIteration == Timer)
            {
                _currIteration = 0;
                return false;
            }
            return true;
        }

        public void Tick()
        {
            if (_startTimer)
            {
                _currTimer += Time.deltaTime;
                if (_currTimer >= _oneSecond)
                {
                    _startTimer = TakeDamage();
                    _currTimer = 0;
                }
            }
        }
    }
}