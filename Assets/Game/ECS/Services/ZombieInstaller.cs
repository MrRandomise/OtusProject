using Leopotam.EcsLite.Entities;
using UnityEngine;
using OtusProject.Component.Zombie;
using UnityEngine.AI;

namespace OtusProject.Content
{
    public sealed class ZombieInstaller : EntityInstaller
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private int _health;
        public int Damage;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _attackDistance;
        [SerializeField] private Animator _animator;
        [SerializeField] private GameObject _drop;

        private void Start()
        {
            _agent.speed = _moveSpeed;
            _agent.stoppingDistance = _attackDistance;
        }

        protected override void Install(Entity entity)
        {
            entity.AddData(new ZombieNavAgent { Value = _agent });
            entity.AddData(new ZombieHealth { Value = _health });
            entity.AddData(new ZombiePosition { Value = transform.position });
            entity.AddData(new ZombieAttackDistance { Value = _attackDistance });
            entity.AddData(new ZombieAnimator { Value = _animator });
            entity.AddData(new ZombieDrop { Value = _drop });
        }

        protected override void Dispose(Entity entity)
        {

        }
    }
}
