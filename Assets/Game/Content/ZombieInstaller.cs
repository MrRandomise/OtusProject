using Leopotam.EcsLite.Entities;
using UnityEngine;
using OtusProject.Component.Zombie;
using OtusProject.Component.Pool;
using UnityEngine.AI;

namespace OtusProject.Content
{
    public class ZombieInstaller : EntityInstaller
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private int _health;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _attackDistance;
        [SerializeField] private Animator _animator;

        private void Start()
        {
            _agent.speed = _moveSpeed;
            _agent.stoppingDistance = _attackDistance;
        }

        protected override void Install(Entity entity)
        {
            entity.AddData(new ZombieNavAgent { Value = _agent });
            entity.AddData(new ZombieHealth { Value = _health });
            entity.AddData(new Position { Value = transform.position });
            entity.AddData(new ZombieAttackDistance { Value = _attackDistance });
            entity.AddData(new ZombieAnimator { Value = _animator });
        }

        protected override void Dispose(Entity entity)
        {

        }
    }
}
