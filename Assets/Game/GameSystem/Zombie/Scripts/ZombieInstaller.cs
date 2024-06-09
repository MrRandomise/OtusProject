using Leopotam.EcsLite.Entities;
using UnityEngine;
using UnityEngine.AI;
using OtusProject.Config.Zombie;
using System;
using OtusProject.Component;

namespace OtusProject.Content
{
    public sealed class ZombieInstaller : EntityInstaller
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Entity _target;
        [SerializeField] private ZombieConfig _zombieConfig;
        [SerializeField] private Entity _drop;
        [SerializeField] private Animator _animator;
        [NonSerialized] public int Damage;

        private void Awake()
        {
            _agent.speed = _zombieConfig.MoveSpeed;
            _agent.stoppingDistance = _zombieConfig.AttackDistance;
            Damage = _zombieConfig.Damage;
        }

        protected override void Install(Entity entity)
        {
            entity.AddData(new NavAgent { Value = _agent });
            entity.AddData(new CurrentTransform { Value = transform });
            entity.AddData(new MaxHealth { Value = _zombieConfig.Health });
            entity.AddData(new CurrentHealth { Value = _zombieConfig.Health });
            entity.AddData(new RotateSpeed { Value = _zombieConfig.RotateSpeed });
            entity.AddData(new AttackDistance { Value = _zombieConfig.AttackDistance });
            entity.AddData(new ObjectAnimator { Value = _animator });
            entity.AddData(new Drops { Value = _drop });
            entity.AddData(new Target { Value = _target });
            entity.AddData(new MoveDirection());
            entity.AddData(new Pool ());
            entity.AddData(new LifeTime {Value = _zombieConfig.DeathTimeout });
            entity.AddData(new ZombieTag ());
            entity.AddData(new CurrentTimer { Value = 0 });
            entity.AddData(new CurrentEntity { Value = entity });
        }

        protected override void Dispose(Entity entity)
        {

        }
    }
}
