using Leopotam.EcsLite.Entities;
using UnityEngine;
using OtusProject.Component.Zombie;
using UnityEngine.AI;

namespace OtusProject.Content
{
    public sealed class ZombieInstaller : EntityInstaller
    {
        public int Damage;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private int _health;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _attackDistance;
        [SerializeField] private Animator _animator;
        [SerializeField] private GameObject _drop;
        [SerializeField] private float _deathTimeout;

        private void Start()
        {
            _agent.speed = _moveSpeed;
            _agent.stoppingDistance = _attackDistance;
        }

        protected override void Install(Entity entity)
        {
            entity.AddData(new ZombieNavAgent { Value = _agent });
            entity.AddData(new ZombieTag { Value = "Zombie" });
            entity.AddData(new ZombieTransform { Value = transform });
            entity.AddData(new ZombieHealth { Value = _health });
            entity.AddData(new ZombieCurrHealth { Value = _health });
            entity.AddData(new ZombiePosition { Value = transform.position });
            entity.AddData(new ZombieAttackDistance { Value = _attackDistance });
            entity.AddData(new ZombieAnimator { Value = _animator });
            entity.AddData(new ZombieDrop { Value = _drop });
            entity.AddData(new ZombieDeathTimeout { Value = _deathTimeout });
            entity.AddData(new ZombieDeathCurrTimeout { Value = 0 });

        }

        protected override void Dispose(Entity entity)
        {

        }
    }
}
