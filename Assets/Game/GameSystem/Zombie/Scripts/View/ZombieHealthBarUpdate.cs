using Leopotam.EcsLite.Entities;
using OtusProject.Component;
using OtusProject.ECSEvent;
using UnityEngine;

namespace OtusProject.View
{
    public sealed class ZombieHealthBarUpdate
    {
        private OnHitInECS _onHitInECS;

        ZombieHealthBarUpdate(OnHitInECS onHitInECS)
        {
            _onHitInECS = onHitInECS;
            _onHitInECS.OnHitEvents += HealthBarUpdate;
        }


        private void HealthBarUpdate(Entity entity)
        {
            //if (_healthCurrentPool.Value.Get(entity).Value != _health.Value.Get(entity).Value)
            //{
            //    _healthBarLine.Value.Get(entity).Value.localScale = new Vector3(1, 1, 1);
            //}
            var h = (float)entity.GetData<CurrentHealth>().Value / entity.GetData<MaxHealth>().Value;
            if (h <= 0)
            {
                h = 0;
            }
            entity.GetData<HealthBar>().Value.localScale = new Vector3(h, 1, 1);
        }
    }
}