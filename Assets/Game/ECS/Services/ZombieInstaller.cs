using Leopotam.EcsLite.Entities;
using UnityEngine;
using OtusProject.Component.Zombie;
using UnityEngine.AI;
using OtusProject.Config.Zombie;
using System;
using OtusProject.Component;

namespace OtusProject.Content
{
    public sealed class ZombieInstaller : EntityInstaller
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Transform _target;
        [SerializeField] private ZombieConfig _zombieConfig;
        [SerializeField] private GameObject _drop;
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
            entity.AddData(new ZombieNavAgent { Value = _agent });
            entity.AddData(new CurrentTransform { Value = transform });
            entity.AddData(new MaxHealth { Value = _zombieConfig.Health });
            entity.AddData(new RotateSpeed { Value = _zombieConfig.RotateSpeed });
            entity.AddData(new AttackDistance { Value = _zombieConfig.AttackDistance });
            entity.AddData(new ZombieAnimator { Value = _animator });
            entity.AddData(new Drops { Value = _drop });
            entity.AddData(new ZombieTarget { Value = _target });
            entity.AddData(new ZombieTag ());
        }

        protected override void Dispose(Entity entity)
        {

        }
    }
}
